class SpeedCalculator:
    @staticmethod
    def calculate_average_speed(distance, time):
        return distance / time if time > 0 else 0


def main():
    try:
        distance = float(input("Введите расстояние между точкой A и точкой B (км): "))
        time = float(input("Введите время перемещения (часы): "))

        if time < 0 or distance < 0:
            raise ValueError(
                "Время должно быть положительным числом, а расстояние неотрицательным."
            )

        calculator = SpeedCalculator()
        average_speed = calculator.calculate_average_speed(distance, time)
        print(f"Средняя скорость автомобиля: {average_speed:.2f} км/ч")

    except ValueError as ve:
        print(f"Ошибка ввода: {ve}")


if __name__ == "__main__":
    main()
