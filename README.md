# Game description

MasterMind is a code-breaking game for two players. Check the game rules [here](https://en.wikipedia.org/wiki/Mastermind_(board_game)).

# Game
I've created this project for my university class. This solution is written in WPF (with MVVM) and in Console Application (with extended functionalities).

- WPF
  * user can guess the code that computer came up with.
- Console Application
  * user can guess the code that computer came up with,
  * user can come up with a code that computer has to guess,
  * user can play with a mode that has numbers instead of letters (colors),
  * user can parameterize the game by selecting the code length and color variety.
  
# Tests
I've also wrote tests to explore the quickest solution that will guess the code.
These tests are available in the tests project. You can specify how many tests should be run.

  * brute force strategy - checks all the 1296 possibilites (very ineffective),
  * color first strategy - checks all the colors first and then brute force the results (ineffective),
  * calculate possibility - check random code and based on the output decide on the next move (very effective),
  * calculate first 4 codes: rryy, rgrg, bbmm, bcbc and then do the same steps as strategy above (very effective).
  
