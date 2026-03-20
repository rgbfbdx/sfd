#include <windows.h>

using System.Timers;

int main()
{
    MessageBox(
        NULL,
        TEXT("Hello, World!"),
        TEXT("My First WinAPI App"),
        MB_OK | MB_ICONINFORMATION
    );
    return 0;
}

#include <windows.h>

int AskUser(const char* question)
{
    return MessageBoxA(NULL, question, "Guess the number", MB_YESNOCANCEL);
}

int main()
{
    while (true)
    {
        int low = 0, high = 100;
        int guess;
        int result;

        MessageBoxA(NULL, "Загадайте число від 0 до 100", "Game", MB_OK);

        while (low <= high)
        {
            guess = (low + high) / 2;

            char buffer[100];
            sprintf_s(buffer, "Ваше число: %d?\nYES = так\nNO = менше\nCANCEL = більше", guess);

            result = AskUser(buffer);

            if (result == IDYES)
            {
                MessageBoxA(NULL, "Я вгадав!", "Result", MB_OK);
                break;
            }
            else if (result == IDNO)
            {
                high = guess - 1;
            }
            else if (result == IDCANCEL)
            {
                low = guess + 1;
            }
        }

        int playAgain = MessageBoxA(NULL, "Грати ще?", "Game", MB_YESNO);
        if (playAgain == IDNO) break;
    }

    return 0;
}

#include <windows.h>
#include <iostream>

int main()
{
    HWND hwnd = FindWindow(NULL, TEXT("Untitled - Notepad"));

    if (hwnd == NULL)
    {
        MessageBox(NULL, TEXT("Блокнот не знайдено!"), TEXT("Error"), MB_OK);
        return 0;
    }

    SendMessage(hwnd, WM_CLOSE, 0, 0);

    return 0;
}#include <windows.h>
#include <ctime>

int main()
{
    HWND hwnd = FindWindow(NULL, TEXT("Untitled - Notepad"));

    if (hwnd == NULL)
    {
        MessageBox(NULL, TEXT("Блокнот не знайдено!"), TEXT("Error"), MB_OK);
        return 0;
    }

    while (true)
    {
        time_t now = time(0);
        tm localTime;
        localtime_s(&localTime, &now);

        char buffer[100];
        sprintf_s(buffer, "Notepad - %02d:%02d:%02d",
            localTime.tm_hour,
            localTime.tm_min,
            localTime.tm_sec
        );

        SetWindowTextA(hwnd, buffer);

        Sleep(1000);
    }

    return 0;
}