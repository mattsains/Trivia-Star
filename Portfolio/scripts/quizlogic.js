//We have jQuery at this point
var left;
$(document).ready(function () {
    left = "29.5%";
    $("#placeholder").css("position", "fixed").css("left", left);
    $("#question1").addClass("question");
    $("#question2").css("display", "").addClass("question").css("left", "100%");
    //get a question
    newQuestion($("#question1"), $("#question2"));
});

function newQuestion(curobj, newobj) {
    $.ajax("Question.asmx/GetQuestion", { type: "POST" }).complete(function (xhr) {
        if ($("#placeholder").css("display") != "none")
            exit($("#placeholder"));
        fill(newobj, xhr, curobj);
        exit(curobj);
        enter(newobj);
    });
}

function enter(obj) {
    obj.css("display", "");
    //absolute positioning gives scrollbars. This is good, but not when we're shifting things around, casuse then scroll bars go mad
    obj.css("position", "fixed");
    obj.css("left", "100%");
    obj.animate({ left: left },500,'easeInOutExpo', function () { obj.css("position", "absolute"); });
}
function exit(obj) {
    obj.css("position", "fixed");
    obj.animate({ left: "-100%" },500,'easeInOutExpo', function () {
        obj.css("display", "none");
        obj.empty();
    });
}

var currentchoices=[];
var answered = 0;
var correctcount = 0;

function fill(obj, xhr, newobj) {
    obj.append("<div class=\"qnum\"> Question " + (answered + 1) + "</div>");
    if ($(xhr.responseXML).find("image").text()!="")
        obj.append("<img width=\"200px\" src=\"images/" + $(xhr.responseXML).find("image").text() + "\"/>");
    obj.append("<h3>" + $(xhr.responseXML).find("text").text() + "</h3>");

    //set up answers
    var correct=$(xhr.responseXML).find("answer").text();

    currentchoices[0]=correct;
    currentchoices[1]=$(xhr.responseXML).find("wrong1").text();
    currentchoices[2]=$(xhr.responseXML).find("wrong2").text();
    currentchoices[3]=$(xhr.responseXML).find("wrong3").text();
    //perform a Fisher-Yates shuffle
    for (var i=3; i>0; i--)
    {
        //random between 0 and i-1
        var j=Math.floor((Math.random()*(i-1))+0);
        var temp=currentchoices[i];
        currentchoices[i]=currentchoices[j];
        currentchoices[j]=temp;
    }

    obj.append("<input type=\"radio\" id=\"ans1\" name=\"ans\" value=\"0\" /><label for=\"ans1\">" + currentchoices[0] + "</label><br/>");
    obj.append("<input type=\"radio\" id=\"ans2\" name=\"ans\" value=\"1\" /><label for=\"ans2\">" + currentchoices[1] + "</label><br/>");
    obj.append("<input type=\"radio\" id=\"ans3\" name=\"ans\" value=\"2\" /><label for=\"ans3\">" + currentchoices[2] + "</label><br/>");
    obj.append("<input type=\"radio\" id=\"ans4\" name=\"ans\" value=\"3\" /><label for=\"ans4\">" + currentchoices[3] + "</label><br/>");

    obj.append("<button id=\"next\">Next</button>");

    obj.find("#next").click(function () {
        var answer = currentchoices[$("input[name=ans]:checked").val()];
        if (!answer) return false;

        answered++;
        var gotcorrect = answer == correct;

        if (gotcorrect) {
            correctcount++;
            obj.append("<p class=\"correct\"><img width=\"32\" class=\"loadnext\" src=\"images/loading.gif\" alt=\"Loading...\"/>Well done!</p>");
        }
        else
            obj.append("<p class=\"wrong\"><img width=\"32\" class=\"loadnext\" src=\"images/loading.gif\" alt=\"Loading...\"/>Wrong!</p>");

        var id = $(xhr.responseXML).find("id").text();

        var time = new Date();
        $.ajax("Question.asmx/PostAnswer", { type: "POST", data: { uid: uid, id: id, answer: gotcorrect} }).complete(function (xhr) {
            setTimeout(function () {
                newQuestion(obj, newobj);
            }, 1000 - (new Date() - time));
        });

        return false;
    });
    obj.append("<button id=\"finish\">Finish</button>");
    obj.find("#finish").click(function () {
        //got to cater for the inconvenient possibility that the user is busy with a question
        var answer = currentchoices[$("input[name=ans]:checked").val()];
        if (answer) {
            answered++;
            var gotcorrect = answer == correct;

            if (gotcorrect) {
                correctcount++;
                obj.append("<p class=\"correct\"><img width=\"32\" class=\"loadnext\" src=\"images/loading.gif\" alt=\"Loading...\"/>Well done!</p>");
            }
            else
                obj.append("<p class=\"wrong\"><img width=\"32\" class=\"loadnext\" src=\"images/loading.gif\" alt=\"Loading...\"/>Wrong!</p>");

            var id = $(xhr.responseXML).find("id").text();

            var time = new Date();
            $.ajax("Question.asmx/PostAnswer", { type: "POST", data: { uid: uid, id: id, answer: gotcorrect} }).complete(function (xhr) {
                setTimeout(function () {
                    endgame(obj, newobj);
                }, 1000 - (new Date() - time));
            });
        }
        else
            endgame(obj, newobj);
        return false;

    });
}

function endgame(obj,newobj) {
    exit(obj);
    newobj.css("display", "");
    newobj.css("position", "fixed");
    newobj.css("left", "100%");
    newobj.animate({ left: left }, function () {
        newobj.css("position", "absolute"); 
        newobj.find("h1.huge").animate({fontSize:"5em"});
    });

    newobj.addClass("center");
    newobj.empty();
    newobj.append("<h3>Quiz Ended!</h3>");
    if (answered == 0)
        newobj.append("<h1 class=\"huge\">0%</h1>");
    else
        newobj.append("<h1 class=\"huge\">" + Math.floor((correctcount / answered) * 100) + "%</h1>");
    newobj.append("<p>You correctly answered " + correctcount + " out of " + answered + " questions.</p>");
    newobj.append("<p><a href=\"/\">Go Home</a></p>");
}