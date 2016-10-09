# DesertShooterVR
Sample first-person-style shooter game for virtual and mixed reality. The goal is to demonstrate how to create a Virtual Reality-style experience using the Microsoft HoloLens. This is inspired by the kind of semi-immersive reality found in other projects like the HoloTour.

HoloLens-based "VR" also has the advantage of allowing room-scale movement without any separate tracking equipment. The military base in this sample is actually quite huge and it would otherwise be very hard (i.e. impossible) to track the user accurately as they walk around the base. You'll need a "convention center"-size space to truly walk all over the map.

This is a work in a progress that I am sharing publicly as I add features.

## Acknowledgements
This project uses assets from the [Tanks! tutorial](https://www.assetstore.unity3d.com/en/?_ga=1.83361502.975056403.1471960723#!/content/46209/) from the Unite 2015 Training Event. Since the military base uses mobile-grade 3D models, they work well on a self-contained mobile device like the HoloLens.

## Features Implemented To Date
* Starter scene that consists of a simple military base in a desert.
* Walk around (physically) when you wear the HoloLens. You can use the arrow keys and mouse look in the Unity editor to debug.
* AirTap to fire a bullet. The crosshair shows where you aim and it uses physics (for now). You can use SPACE in the Unity editor to debug.

## Implementation Notes
* The projectile system uses Unity's physics system, which unfortunately doesn't work too well when you fire bullets at 300 m/s. High performance physics are failing and some collisions simply don't occur, or they get triggered too late. I will use the classic "cheat" used in many standard first-person shooters and raycast the impact of my bullets and forego the actual "physics" drop.
* This project uses a Skybox, unlike other HoloLens project that usually rely on a black uniform background which would provide transparency on HoloLens. The Skybox preserves the relative feeling of immersion.
* The height of the user is currently locked at 1.7m to simulate the eye-level of an adult who is 6ft tall. I will eventually detect the height of the HoloLens vs the floor for a more accurate experience.

## Follow Me
* Twitter: [@ActiveNick](http://twitter.com/ActiveNick)
* Blog: [AgeofMobility.com](http://AgeofMobility.com)
* SlideShare: [http://www.slideshare.net/ActiveNick](http://www.slideshare.net/ActiveNick)
