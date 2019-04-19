# Sound Manager

## Description
The SoundManager.cs and Sound.cs are scripts used to control and create sound for the Debugger game. The SoundManager script uses a singleton pattern to ensure that there is only one instance of the object in a given scene and manages all sounds that are going to be played in the scene. The Sound script uses a template pattern to allow the background music and different sound effects of the game to have different capabilities.

## Adding a sound
All sounds that are used in the game can be found in the Assets/0_src/Blakely/Resources. To add a sound that you want to be accessible in the game, place a .wav or .mp3 file in the Resources folder.

To play a sound within the game:

1. Go to the BF_Sound Manager  object in the scene hierachy
2. In the inspector under the script Sound Manager there will be two drop down lists: Music and Sound Fx
3. Click on the Sound Fx arrow
   - If the sound you want to play in the scene is already in the list then skip to step 6 
4. Go to the size variable and increment it by however many more sounds you want to add and press enter
5. Once the size is incremented fill in the necessary fields of: Sound ID (what you want to name the sound), Volume (0f - 1f), Clip (Click the target and select the .wav or .mp3 file you want), and Is Haptic (Allows the option of vibrating the controller if in applicable format)
6. Once your sound is in the Sound Fx then you can go to where you want the sound to play or stop in your script and add the code:
'''
FindObjectOfType<SoundManager>().Play("YourSoundId");
'''
or
'''
FindObjectOfType<SoundManager>().Stop("YourSoundId");
'''