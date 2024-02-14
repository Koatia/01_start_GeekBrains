from random import randint

print("Привет, мир")

a = 5
b = 6
print(a + b)

name = "Константин"
age = 49
print(name + " " + str(age))

# Угадай число
number = randint(1, 100)
print(number)
for i in range(1, 11):
    print("Попытка", i)
    ask = int(input("Угадай число: "))
    if number == ask:
        print("Угадал!!!")
        break
    elif ask < number:
        print("Ваше число меньше загаданного")
    elif ask > number:
        print("Ваше число больше загаданного")

# Скажи пароль v1
password = "secret"
ans = input("Скажи пароль: ")

if password == ans:
    print("Можешь пройти")
else:
    print("Пароль не совпал")

# Скажи пароль v2
password = "secret"
ans = input("Скажи пароль: ")
while password != ans:
    print("NO!!!")
    ans = input("Новая попытка: ")
print("YES!!!")
