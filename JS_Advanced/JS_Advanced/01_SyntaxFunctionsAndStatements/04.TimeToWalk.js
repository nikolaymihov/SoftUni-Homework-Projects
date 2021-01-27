function TimeToWalk(numberOfSteps, footprintInMeters, speedInKmPerH) {
    let distanceInMeters = numberOfSteps * footprintInMeters,
        speedInMetersPerSec = speedInKmPerH / 3.6,
        time = distanceInMeters / speedInMetersPerSec,
        restTime = Math.floor(distanceInMeters / 500);
  
    let timeInMin = Math.floor(time / 60),
        timeInSec = Math.round(time - (timeInMin * 60)),
        timeInHr = Math.floor(time / 3600);
  
        console.log((timeInHr < 10 ? "0" : "") + timeInHr + ":" + (timeInMin + restTime < 10 ? "0" : "") + (timeInMin + restTime) + ":" + (timeInSec < 10 ? "0" : "") + timeInSec);
  
}

TimeToWalk(4000, 0.60, 5);
  
TimeToWalk(2564, 0.70, 5.5);