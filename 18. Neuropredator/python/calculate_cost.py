# coding: utf-8

import tkinter as tk

ROOT = tk.Tk()
ROOT.title("Расчет заработной платы")

# Константы
SOCIAL_SECURITY_RATE = 30.0


# Функции
def calculate_cost(
		hours_worked, hourly_rate, social_security_rate=SOCIAL_SECURITY_RATE
):
	gross_pay = hours_worked * hourly_rate
	social_security = gross_pay * social_security_rate / 100.0
	net_pay = gross_pay - social_security
	return gross_pay, social_security, net_pay


def calculate():
	hours = float(HOURS_ENTRY.get())
	rate = float(RATE_ENTRY.get())

	gross, social, net = calculate_cost(hours, rate)

	RESULT_LABEL[
		"text"
	] = f"""
	Брутто: {gross:.2f} руб.
	Отчисления: {social:.2f} руб.
	Нетто: {net:.2f} руб.
	"""


# Интерфейс
HOURS_LABEL = tk.Label(text="Отработано часов:")
HOURS_ENTRY = tk.Entry()

RATE_LABEL = tk.Label(text="Почасовая ставка:")
RATE_ENTRY = tk.Entry()

CALCULATE_BUTTON = tk.Button(text="Рассчитать", command=calculate)

RESULT_LABEL = tk.Label(text="")

HOURS_LABEL.grid(row=0, column=0)
HOURS_ENTRY.grid(row=0, column=1)

RATE_LABEL.grid(row=1, column=0)
RATE_ENTRY.grid(row=1, column=1)

CALCULATE_BUTTON.grid(row=2, column=1, pady=10)

RESULT_LABEL.grid(row=3, column=0, columnspan=2)

ROOT.mainloop()
