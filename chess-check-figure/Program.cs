using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_check_figure
{
    public class Board
    {
        //переменные первой фигуры
        public char figure1;
        public char letter1;
        public int letternum1;
        public int number1;

        //переменные второй фигуры
        public char letter2;
        public int letternum2;
        public int number2;

        // фразы для проверки
        public string checkFigure = "KQRBNp";
        public string checkLetter = "abcdefgh";
        public bool checkFlag = false;

        //массив шахматной доски (взят 9 на 9 для удобства. массив идет от 0 до 8)
        public int[,] board = new int[9, 9];

        public void CharToInt() //метод перевода символа в цифру (буквы на шахматной доске)
        {
            //первая фигура
            if (letter1 == 'a') letternum1 = 1;
            if (letter1 == 'b') letternum1 = 2;
            if (letter1 == 'c') letternum1 = 3;
            if (letter1 == 'd') letternum1 = 4;
            if (letter1 == 'e') letternum1 = 5;
            if (letter1 == 'f') letternum1 = 6;
            if (letter1 == 'g') letternum1 = 7;
            if (letter1 == 'h') letternum1 = 8;
            //вторая фигура
            if (letter2 == 'a') letternum2 = 1;
            if (letter2 == 'b') letternum2 = 2;
            if (letter2 == 'c') letternum2 = 3;
            if (letter2 == 'd') letternum2 = 4;
            if (letter2 == 'e') letternum2 = 5;
            if (letter2 == 'f') letternum2 = 6;
            if (letter2 == 'g') letternum2 = 7;
            if (letter2 == 'h') letternum2 = 8;
            FiguresToArray(); //вызов метода переноса переменных фигур на шахматную доску
        }

        public void FiguresToArray() //метод перенос переменных фигур на шахматную доску
        {
            board[letternum1, number1] = 1;
            board[letternum2, number2] = 2;
            Check(); //вызов метода проверки
        }

        public void Check() //метод проверки
        {
            if (figure1 == 'p') //логика проверки для пешки
            {
                if ((letternum1 + 1 < 9 && number1 + 1 < 9) && board[letternum1 + 1, number1 + 1] == 2) Beat();
                else if ((letternum1 - 1 > 0 && number1 + 1 < 9) && board[letternum1 - 1, number1 + 1] == 2) Beat();
                else NotBeat();
            }
            if (figure1 == 'N') //логика проверки для коня
            {
                if ((letternum1 + 1 < 9 && number1 + 2 < 9) && board[letternum1 + 1, number1 + 2] == 2) Beat();
                else if ((letternum1 + 2 < 9 && number1 + 1 < 9) && board[letternum1 + 2, number1 + 1] == 2) Beat();
                else if ((letternum1 + 2 < 9 && number1 - 1 > 0) && board[letternum1 + 2, number1 - 1] == 2) Beat();
                else if ((letternum1 + 1 < 9 && number1 - 2 > 0) && board[letternum1 + 1, number1 - 2] == 2) Beat();
                else if ((letternum1 - 1 > 0 && number1 - 2 > 0) && board[letternum1 - 1, number1 - 2] == 2) Beat();
                else if ((letternum1 - 2 > 0 && number1 - 1 > 0) && board[letternum1 - 2, number1 - 1] == 2) Beat();
                else if ((letternum1 - 2 > 0 && number1 + 1 < 9) && board[letternum1 - 2, number1 + 1] == 2) Beat();
                else if ((letternum1 - 1 > 0 && number1 + 2 < 9) && board[letternum1 - 1, number1 + 2] == 2) Beat();
                else NotBeat();
            }
            if (figure1 == 'B')
            {
                CheckBishop(); //вызов метода проверки для слона
                if (!checkFlag) NotBeat();
            }
            if (figure1 == 'R')
            {
                CheckRook(); //вызов метода проверки для ладьи
                if (!checkFlag) NotBeat();
            }
            if (figure1 == 'Q') //логика проверки для ферзя
            {
                CheckBishop(); //вызов метода проверки для слона
                if (!checkFlag) CheckRook(); //вызов метода проверки для ладьи
                if (!checkFlag) NotBeat();
            }
            if (figure1 == 'K') // логика проверки для короля
            {
                for (int i = number1-1; i<=number1+1; i++) // квадрат вокруг короля
                    for (int j = letternum1-1; j <= letternum1 + 1; j++)
                        if ((i < 9 && j < 9 && i > 0 && j > 0) && board[i, j] == 2) Beat();
                if (!checkFlag) NotBeat();
            }
        }

        public void CheckBishop() // метод проверки для слона
        {
            for (int i = letternum1 + 1, j = number1 + 1; i < 9; i++) // по диагонали справа вверх от фигуры
            { 
                if ((i < 9 && j < 9) && board[i, j] == 2) Beat();
                j++;
            }
            for (int i = letternum1 + 1, j = number1 - 1; i < 9; i++) //по диагонали справа вниз от фигуры
            {
                if ((i < 9 && j > 0) && board[i, j] == 2) Beat();
                j--;
            }
            for (int i = letternum1 - 1, j = number1 + 1; i > 0; i--) //по диагонали слева вверх от фигуры
            {
                if ((i > 0 && j < 9) && board[i, j] == 2) Beat();
                j++;
            }
            for (int i = letternum1 - 1, j = number1 - 1; i > 0; i--) //по диагонали слева вниз от фигуры
            {
                if ((i > 0 && j > 0) && board[i, j] == 2) Beat();
                j--;
            }
        }

        public void CheckRook()
        {
            for (int i = 1; i < 9; i++) // проверка по горизонтали
                if (board[i, number1] == 2) Beat();
            for (int i = 1; i < 9; i++) // проверка по вертикали
                if (board[letternum1, i] == 2) Beat();
        }

        public void Beat() // найдена фигура
        {
            Console.WriteLine("Фигура может съесть другую");
            checkFlag = true;
        }

        public void NotBeat() // не найдена фигура
        {
            Console.WriteLine("Фигура НЕ может съесть другую");
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - для выхода из программы\n" +
                    "Введите информацию о первой фигуре:\n" +
                    "1. K - король, Q - ферзь, R - ладья, B - слон, N - конь, p - пешка\n" +
                    "2. Буква поля от a до h\n" +
                    "3. Цифра поля от 1 до 8\n" +
                    "Например, Qe4 - Ферзь на e4");

                string temp;
                try
                {
                    temp = Console.ReadLine();
                    if (temp == "0") break; // выход из программы
                    if (temp.Length != 3) // проверка длины введенной строки
                        throw new Exception(); // если неравно 3 -> запустить исключение (отправляем в catch)

                    figure1 = temp[0];
                    bool cF = false;
                    for (int i = 0; i < checkFigure.Length; i++)
                        if (figure1 == checkFigure[i])
                            cF = true;
                    if (!cF) throw new Exception();

                    letter1 = temp[1];
                    bool cL = false;
                    for (int i = 0; i < checkLetter.Length; i++)
                        if (letter1 == checkLetter[i])
                            cL = true;
                    if (!cL) throw new Exception();

                    number1 = int.Parse(Convert.ToString(temp[2]));
                    if (number1 < 1 || number1 > 8) throw new Exception();
                    break;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.\n" +
                        "Нажмите any key для продолжения.");
                    Console.ReadKey();
                    continue;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите местоположение второй фигуры:\n" +
                                  "Например, e4");
                string temp;
                try
                {
                    temp = Console.ReadLine();
                    if (temp == "0") break; // выход из программы
                    if (temp.Length != 2) // проверка длины введенной строки
                        throw new Exception(); // если неравно 2 -> запустить исключение (отправляем в catch)

                    letter2 = temp[0];
                    bool cL = false;
                    for (int i = 0; i < checkLetter.Length; i++)
                        if (letter2 == checkLetter[i])
                            cL = true;
                    if (!cL) throw new Exception();

                    number2 = int.Parse(Convert.ToString(temp[1]));
                    if (number2 < 1 || number2 > 8) throw new Exception();

                    if (letter1 == letter2 && number1 == number2)
                    {
                        Console.WriteLine("Данная клетка поля занята. Попробуйте снова.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.\n" +
                                      "Нажмите any key для продолжения.");
                    Console.ReadKey();
                    continue;
                }
            }
            CharToInt();// вызов метода перевода символа в цифру (буквы на шахматной доске)
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true) // цикл помогает начать снова, так как переменные обнуляются
            {
                Board brd = new Board(); // создаем "доску"
                brd.Start(); // запускаем меню
                Console.WriteLine("Начать снова? y/n");
                if (Console.ReadLine() == "n") break; // при нажатии 'n' цикл заканчивается
            }
        }
    }
}
