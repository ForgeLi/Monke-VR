# Monke VR

An original Unity/C# starter for a Gorilla Tag-inspired VR game targeting Meta Quest 2.

## Current milestone
- Physics-based hand-pushing locomotion starter.
- Configurable hand radius and movement speed.
- Unity XR rig integration points.

## Unity setup
1. Install Unity Hub and a Unity LTS version with Android Build Support, Android SDK/NDK tools, and OpenJDK.
2. Create a 3D Core Unity project.
3. Install XR Plugin Management and XR Interaction Toolkit from Package Manager.
4. Enable OpenXR for Android and the Meta Quest feature group if available in your package version.
5. Add an XR Origin with a Camera and left/right hand transforms.
6. Add a Rigidbody and CapsuleCollider to the player root; freeze Rigidbody rotation.
7. Add PlayerHandLocomotion to the player root and assign both hand transforms and colliders.
8. Add a non-trigger SphereCollider to each hand.
9. Build for Android and deploy to your Quest headset.

This repository is source code only, not a finished game or installable APK. Multiplayer, maps, cosmetics, and menus are later milestones. Test VR locomotion in a safe, open play area.

## Structure
- Assets/Scripts/PlayerHandLocomotion.cs — basic physics-based hand locomotion.
- Assets/Scripts/HandColliderSetup.cs — hand collision helper.
- Assets/Scripts/PlayerBodySetup.cs — player Rigidbody helper.

No Gorilla Tag assets or proprietary code are included.