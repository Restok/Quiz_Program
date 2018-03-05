import random
import math
entries = input("Enter the number of entries you would like to insert");
allquestions = set()
sqltext = open("sql.txt", "w")
sqltext.write("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")
print("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")
def addition():
  for x in range(int(entries)):
    
    r1 = random.randint(0, 1000)

    r2 = random.randint(0, 1000)

    correctanswer = r1+r2
    possibleanswers = []
    domain = set(correctanswer+x for x in range(-100, 100))
    domain.discard(correctanswer)  # make sure you don't select the correct one
    possibleanswers = random.sample(domain, 3)  # select 3 random ones
    possibleanswers.append(correctanswer)
    random.shuffle(possibleanswers)
    a, b, c, d = possibleanswers
    print(f"('', 'Math', 'What is {r1} + {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Addition'),")
    sqltext.write(f"('', 'Math', 'What is {r1} + {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Addition'),")

def subtraction():
  for x in range(int(entries)):
    
    r1 = random.randint(0, 1000)

    r2 = random.randint(0, 1000)

    while r1<r2:

      r1 = random.randint(0, 1000)
      
      r2 = random.randint(0, 1000)

    correctanswer = r1-r2
    possibleanswers = [];
    domain = set(correctanswer+x for x in range(-100, 100))
    domain.discard(correctanswer)  # make sure you don't select the correct one
    possibleanswers = random.sample(domain, 3)  # select 3 random ones
    possibleanswers.append(correctanswer)
    random.shuffle(possibleanswers)
    a, b, c, d = possibleanswers
    print(f"('', 'Math', 'What is {r1} - {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Subtraction'),")  
    sqltext.write(f"('', 'Math', 'What is {r1} - {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Subtraction'),")

def multiplication():
  for x in range(int(entries)):
    
    r1 = random.randint(0, 200)

    r2 = random.randint(0, 100)

    correctanswer = r1*r2
    possibleanswers = []
    domain = set(correctanswer+x for x in range(-100, 100))
    domain.discard(correctanswer)  # make sure you don't select the correct one
    possibleanswers = random.sample(domain, 3)  # select 3 random ones
    possibleanswers.append(correctanswer)
    random.shuffle(possibleanswers)
    a, b, c, d = possibleanswers
    print(f"('', 'Math', 'What is {r1} x {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Multiplication'),")
    sqltext.write(f"('', 'Math', 'What is {r1} x {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Multiplication'),")

def division():
  for x in range(int(entries)):
    
    r1 = random.randint(100, 10000)

    r2 = random.randint(1,100)

    while not(r1%r2 == 0):
      
      r1 = random.randint(50, 1000)

      r2 = random.randint(1,50)

    correctanswer = r1/r2
    possibleanswers = []
    domain = set(correctanswer+x for x in range(-100, 100))
    domain.discard(correctanswer)
    possibleanswers = random.sample(domain, 3)
    possibleanswers.append(correctanswer)
    random.shuffle(possibleanswers)
    a, b, c, d = possibleanswers
    print(f"('', 'Math', 'What is {r1} divided by {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Division'),")  
    sqltext.write(f"('', 'Math', 'What is {r1} divided by {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Division'),")

def powers():
  for x in range(int(entries)):
    
    r1 = random.randint(1, 1000)

    r2 = random.randint(0, 3)
    correctanswer = r1^r2
    possibleanswers = []
    domain = set(correctanswer+x for x in range(-100, 100))
    domain.discard(correctanswer)  # make sure you don't select the correct one
    possibleanswers = random.sample(domain, 3)  # select 3 random ones
    possibleanswers.append(correctanswer)
    random.shuffle(possibleanswers)
    a, b, c, d = possibleanswers
    print(f"('', 'Math', 'What is {r1} to the power of {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Powers'),")  
    sqltext.write(f"('', 'Math', 'What is {r1} to the power of {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Powers'),")
def squareroot():
  for x in range(int(entries)):
    
    r1 = random.randint(0, 1000)

    r2 = r1*r1

    correctanswer = r1
    possibleanswers = []
    domain = set(correctanswer+x for x in range(-10, 10))
    domain.discard(correctanswer)  # make sure you don't select the correct one
    possibleanswers = random.sample(domain, 3)  # select 3 random ones
    possibleanswers.append(correctanswer)
    random.shuffle(possibleanswers)
    a, b, c, d = possibleanswers
    print(f"('', 'Math', 'What is the squareroot of {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Powers'),")  
    sqltext.write(f"('', 'Math', 'What is the squareroot of {r2}?', '{correctanswer}','{a}', '{b}', '{c}', '{d}', 'Powers'),")

subtraction()

print('\n\n')
sqltext.write('\n\n')

sqltext.write("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")
print("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")

multiplication()

print('\n\n')
sqltext.write('\n\n')

sqltext.write("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")
print("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")

division()

entries = 50

print('\n\n')
sqltext.write('\n\n')

sqltext.write("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")
print("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")

powers()

print('\n\n')
sqltext.write('\n\n')

sqltext.write("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")
print("INSERT INTO `toredatabase`.`questions` (`id`, `category`, `question`, `Correct_Answer`, `answer_A`, `answer_B`, `answer_C`, `answer_D`, `Details`) VALUES")

squareroot()


