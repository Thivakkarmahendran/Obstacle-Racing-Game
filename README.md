# CS576 Final Project - Obstacle racing game
Members - Thivakkar Mahendran, Moses Reid, Chieh Min Chung

# How to Play
- Up arrow -> to go accelerate the car
- Down arrow -> to go reverse 
- left/right arrow -> to turn the car
- space bar -> to brake the car
- escape key -> to pause the game

# Features
- Main menu scene to start the game with instructions on how to play the game
- Car selection scene to select the car type
- Race Track scence where the car goes through obstacles to reach the finish line
    - The camera follows the car and shows the speed, current lap, best time, alert warnings and info warning
    - Boulders randomly falling from the hill, if car hits the boulder then the health of the car goes down by 20%
    - Snow area where the car skids easily
    - Bumpy area on the road making it harder to handle the car
    - Wrecking balls that damage the car by 20% if hit
    - Water fall area where the car slides to the right making it easier for the car to fall of the map
    - Trees in the middle of the road making the car to drive carefully
    - wind zone which makes the car shift towards a random direction, possible for the car to fall of the map by the winds
    - Finish zone to check race completion
        - Shows the completed time
        - Saves the current times locally if it is the best time
    - Checkpoints through out the map to deter cheating and if the car falls of the map or gets damaged completely the car respwans from the last completed checkpoint
        - The player will get alerted if the player misses any checkpoints
    - Mystery boxes placed throughout the map to unlock special powers - selection of special power is random
        - Fast -> makes the car go super fast for 5 seconds
        - Slow -> makes the car go super slow for 5 seconds
        - Bigger -> makes the car get bigger for 5 seconds
        - Smaller -> makes the car get smaller for 5 seconds 
        - Max Health -> increases the health of the car to 100%
        - Stealth -> car can't get damages for 5 seconds
    - Pause menu lets the player start, restart, or go to the main menu
- AI car competes in the race track by autonomously driving through the map  

# Contributions
- Thivakkar Mahendran - worked on the creation of the map/terrain + the obstacles in the map
    - Whole of ball.cs
    - Whole of boulderScipt.cs
    - Some of CarController.cs
        - line 368 to 440
    - Whole of CheckPoint.cs
    - Whole of checkpointTracker.cs
    - Whole of mysteryBox.cs
    - Whole of terrainScipt.cs
    - Whole of windArea.cs
    - Whole of WreckingBallScript.cs
- Moses Reid - worked on the car + car controls
    - Whole of CameraFollower.cs
    - Whole of CarAI.cs
    - Whole of ChangeScene.cs
    - Whole of FinishLine.cs
    - Whole of GetBestTime.cs
    - Whole of Path.cs
    - Whole of RaceSystem.cs
    - Whole of SelectCar.cs
    - Whole of SelectStage.cs
    - Whole of Unpause.cs
- Chieh Min Chung - worked on the main menu, car selection menu, and AI car
    - Most of CarController.cs
    - Whole of CarRotation.cs
    - Whole of HealthBar.cs
    - Whole of MakeObjectTransparent.cs
    - Whole of OpenCloseRules.cs
    - Whole of Speedometer.cs
 
