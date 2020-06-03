
function registerArticleTimer(seconds, indicatorDom, nextUrl) {
    var timeRest = seconds;

    indicatorDom.text(timeRest);

    setTimeout(function () {
        window.location.href = nextUrl;
    }, seconds * 1000);

    setInterval(function () {
        timeRest = timeRest - 1;
        indicatorDom.text(timeRest);
    }, 1000);
}