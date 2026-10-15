using Observer.Exercise;

var downloader = new Downloader();
var completeListener = new CompleteListener();
var progressDisplay = new ProgressDisplay();

downloader.AddListener(completeListener);
downloader.AddListener(progressDisplay);

downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.RemoveListener(progressDisplay);
downloader.UpdateProgress(100);

downloader.RemoveListener(completeListener);
