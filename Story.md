<h1 align="center">Story</h1>


<br>
<h2 align="center">Endings</h2>
<p align="center">
There are 9 endings, each ending is selected on diffrent state of the game, depending on the choices player made.<br>
  At the end of the game, ending is displayed as newspaper article, using newspaper enum.<br><br>
  
1| PlayerSpotted - Player has been seen twice at suspicious place.<br>
2| NeighbourRingLetter - Police found Ring and ForgetLetter at neighbours house.<br>
3| NeighbourRingWeapon - Police found Ring and MurderWeapon at neighbours house.<br>
4| NeighbourLetterWeapon - Police found ForgetLetter and MurderWeapon at neighbours house.<br>
5| PlayerWeapon - Police found MurderWeapon at players house.<br>
6| PlayerClothes - Garbage man has found victims clothes in players trash.<br>
7| PlayerMainSuspect - Player was the main suspect and was arrested.<br>
8| NeighbourMainSuspect - Neighbour was the main suspect and was arrested.<br>
9| PoliceGivesUp - Police could not find good evidence, case closed.<br>

Endings 1-6 happen before all stages take place, 7-9 happen after the last stage if no other ending was occured.
</p>


<br>
<h2 align="center">Choices</h2>
<p align="center">
On each stage of the game(there are 5 stages), player has to choose between 3 options. Each of the options changes NarratorStateMachine variables, this variables are:

Suspicion - show how much police suspects the player.<br>
Mislead - indicated the players mislead of the police.<br>
SpottedCount - keeps track of how many times player has been seen.<br>
Ring/Letter/Weapon Planted - controll what is at a neighbours house.<br>

Suspicion and Mislead are used to choose the endings from 7 to 9. But also determine if values of these variables should be changed.
For example, if player choosen B options on stage "Lost Keys" Suspicion will only be incresed if player is already suspected.

SpottedCount is incresed each time player is spotted in the suspicious place, and if it reaches 2, game ends with ending 1.

Planted indicator are used to check endings from 2 to 4, which is framing the neighbour.
</p>




<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
