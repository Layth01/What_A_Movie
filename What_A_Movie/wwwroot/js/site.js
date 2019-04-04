var myOptions = {
    "nativeControlsForTouch": false,
    controls: true,
    autoplay: true,
    width: "640",
    height: "400",
}
myPlayer = amp("azuremediaplayer", myOptions);
myPlayer.src([
    {
        "src": "//laythchebbi-frct1.streaming.media.azure.net/b070c816-72e5-4cf0-8c3e-720f5f55a7bc/Gilfoyle was an illegal immigran.ism/manifest",
        "type": "application/vnd.ms-sstr+xml"
    }
]);


