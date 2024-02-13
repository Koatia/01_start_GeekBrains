import requests
import json
import matplotlib.pyplot as plt
from datetime import datetime, timedelta

# Ты разработчик на python, визуализируй алгоритм работы программного кода для бизнес-аналитика, опиши что делает код и напиши недостатки:
# " Визуализируй алгоритм: ы разработчик, тебе нужно донести до бизнес-аналитика, как работает алгоритм Напиши алгоритм для данной программы на языке, python:

# Ваш API-ключ
api_key = "d1b6e30e08caa89ecf544967"

# Базовая и целевая валюты
base_currency = "USD"
target_currency = "RUB"

# Даты начала и конца периода
start_date = datetime.strptime("2023-01-01", "%Y-%m-%d")
end_date = datetime.strptime("2023-12-31", "%Y-%m-%d")

# Пустые списки для дат и курсов
dates = []
rates = []

# Цикл для перебора каждого дня в выбранном диапазоне дат
current_date = start_date
while current_date <= end_date:
	# Преобразуем datetime в строку для запроса
	date_str = current_date.strftime("%Y-%m-%d")

	# Запрос к API
	response = requests.get(
		f"https://api.exchangerate-api.com/v4/latest/{base_currency}?base={base_currency}&symbols={target_currency}&api_key={api_key}"
	)
	data = json.loads(response.text)

	# Добавляем дату и курс в список
	dates.append(date_str)
	rates.append(data["rates"][target_currency])

	# Переходим к следующему дню
	current_date += timedelta(days=1)

# Построение графика
plt.figure(figsize=(12, 6))
plt.plot(dates, rates)
plt.xlabel("Date")
plt.ylabel(f"{base_currency} to {target_currency}")
plt.title(f"Exchange Rate from {base_currency} to {target_currency}")
plt.xticks(dates[::30])  # показывать каждую 30-ю дату для лучшей читаемости
plt.show()
