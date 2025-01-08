import random # random module

def getAns(a,b): # function gets user guess based on set bounds
    ans = '' # set var to bad value to init while loop
    while ans == '' or ans < a or ans > b: # while any are true
        try:
            ans = int(input("Choose a Number: ")) # get a num from user
        except ValueError:
            print('Invalid Input.') # if ans is not a num
        if ans < a:
            print("Number exceeds Min Bound.") # if ans is too low
        if ans > b:
            print("Number exceeds Max Bound.") # if ans is too high
    return ans # return ans when valid

def genNum(a,b): # function returns random value based on inclusive bounds
    return random.randint(a,b)

def getBound(): # function retrieves bound args from user
    upper = '' # bad value for loop
    lower = '' # bad value for loop
    while upper == '' or lower == '': # while bad;
        try:
            upper = int(input('Choose the Max Bound: ')) # get num from user
            lower = int(input('Choose the Min Bound: ')) # get num from user
        except ValueError: # if not a num
            print("One or more inputs were invalid. Try again.")
    return lower, upper # return as a tuple

def checkNum(): # function that plays the game
    mistakes = 0 # set accumulator for attempts
    bounds = getBound() # call for bound args
    guess = getAns(bounds[0], bounds[1]) # call for user guess
    ans = genNum(bounds[0],bounds[1]) # call for computer chosen answer
    while guess != ans and mistakes < 3: # if ans incorrect, and less than 3 mistakes
        mistakes += 1 # add a mistake
        if guess > ans:
            print("Too High. Try again.") # if ans too high, tell user
            guess = getAns(bounds[0],bounds[1]) # call for another guess
        elif guess < ans:
            print("Too Low. Try again.") # if ans too low, tell user
            guess = getAns(bounds[0],bounds[1]) # call for another guess
    if mistakes == 3: # catches failures
        print("The Correct Answer was:", ans) # tell user correct answer
        return -1 # return fail
    else:
        return 0 # return win

def main(): # looping menu function
    st = '' # bad variable
    while st != "q": # while st is not q
        print("Let's play a Guessing Game!\n" # tell user what this program is
              "Play: (p)\n"
              "Quit: (q)")
        choices = ['p', 'q'] # define choices
        st = input(':: ').lower() # get the user's choice
        while st.lower() not in choices:
            print("Invalid Selection.") # tell user invalid selections
            st = input(':: ').lower()
        if st == 'p': # play the game
            res = checkNum()
            if res == -1:
                print("No more attempts. You lose.")
            else:
                print("Congratulations! You win!")
        else: # close the game
            print("Closing..")

if __name__ == "__main__":
    main()
