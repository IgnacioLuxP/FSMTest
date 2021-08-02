# FSMTest (buggy)
 Barebones implementation of Bardent's State Machine with a static character with a couple animations and 3 basic states: Idle, Walk, Attack.
 Made in Unity version 2019.2.17f1 but should be upgradeable to more recent versions.

## Issue:
 Small delay when the Attack state detects its animation has finished playing and the state actually exits, ranging from 0.003 seconds to 0.01. It extends to any other state that derives from Ability State or that uses AnimationEvents.
 
## How to Use:
 Check the console's time readings. This script has two possible methods for exiting the Attack state. You can test either one in runtime by enabling or disabling the **TimeBasedTransition** bool in the Inspector (on the Player game object).
 
 * The default uses a simple If check against the Attack animation's [normalizedTime](https://docs.unity3d.com/ScriptReference/AnimatorStateInfo-normalizedTime.html).
 There is no delay between the animation finishing and the state's exit time. 
 
 * The other method uses an AnimationEvent (as seen in Bardent's guides) at the end of the Attack animation clip which triggers a function that sets flag **isAnimationFinished** to true. The Update function on the Attack state checks whether this flag is true. If it is true, it changes the state to Idle. However, there's a small delay after this flag is changed and the Attack state actually exits. 

### Controls: 
 - No directional input: Idle state
 - Arrow Keys or Left Joystick: Move state
 - Click or X (Fire1): Attack state


