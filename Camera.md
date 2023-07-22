<h1 align="center">Camera</h1>


<br>
<h2 align="center">State machine</h2>
<p align="center">
Cameras behaviour is controlled by state machine with 3 state(Menu, Newspaper, Board), each state has its own StateLabel in StateLabels enum.

  ChangeState method is responsible for changing the state.<br>
  First it calls the current state Exit, sets current state to state from array using given label, and calls Enter method of this state.
ChangeState can be used with StateLabel or CameraStateLabelHolder(used for buttons in the inspector).
</p>


<br>
<h2 align="center">Moving</h2>
<p align="center">
  Since camera MurdersMystery uses cinemachine, there are two game objects that have to be moved to achieve wanted result, Follow and LookAt.<br>
  
  Both of these gameobjects have their own controller, that has one method with overrides(Move instant, Lerp or Lerp with curve).
  The moving logic happens in seperate class of the same script file, this class contains 3 methods(2 coroutines), each called from previous mentioned overides.

  There is also a fov controller, and it is only useable in the cameras newspaper state, to help players read what written on the paper.
</p>




<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
