# Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times

def get_cows_and_bulls(secret, guess):
    cows = bulls = 0
    for i in range(4):
        if guess[i] == secret[i]:
            bulls += 1
        elif guess[i] in secret:
            cows += 1
    return cows, bulls

def play_game():
    secret=input("Enter secret word: ")

    while True:
        guess=input("Enter guess: ")
        cows,bulls=get_cows_and_bulls(secret,guess)
        print("Cows: ",cows)
        print("Bulls: ",bulls)
        if(bulls==4):
            print("You win")
            break
play_game()