# Exam
Explanation of choices 


Main Design.

If we can use "multiple" decks, we need to be able to have duplicate decks and cards. So I have chosen a direct representation of the decks and cards, instead
of simulating their way of working. Doing it this way it also has better scalability: we can use these classes for other card games.
By saving references of each card both in the heap and deck, we can "manipulate" them individually, for example "mark" them.
Thus, each card is unique, is handled individually, and can be moved around, without being copied or deleted.
I have defined the card comparison logic in a class that is part of the game class. By this way all classes are reusable for any other type of card game.

Deck.

The basic functionality of a deck (building the deck) is common to all of them, so I have decided to use inheritance, implementing the common logic in the
parent class, and specifying the parameters and specific logic in each derived class.
To store the names of each card (aliases) I have used a dictionary, because it is faster than an array. It would be useful if we use an alias for each letter
and a lot of decks.I have decided to make them static for storing just a single reference to their values. It's enough, we don't need to store one copy for
every instance of the same deck.I only initialize the dictionary the first time we create an instance of a deck, not storing dictionaries of "not in use" decks.
The current definition of card and deck allows adding cards out of suit (for example, tarot cards) in any new deck that we'll design.

Heap.

I try to follow a design that reflects reality. We have a shuffle method where I implement randomness. Instead of drawing one card from the List at a time,
I only keep track of the card in play. The first operation has a complexity O (n), the second O (1). (.Net reference)
Ideally, I would have used a tree-like structure, but there's no direct implementation available in C #.
This implementation allows us to reuse the code for other card games.


Rules.

I have created a class, which only serves to define rules for this game and probably any other that draws cards one at a time
If we would be adding more games, I would create and use an interface.

Card.

The Alias property, in addition to adding a more real identifier, is helpful to add additional cards, outside of any suit. They would work like wildcards
or dummies assigning out of range values (-1) to the value and the suit propierties.
