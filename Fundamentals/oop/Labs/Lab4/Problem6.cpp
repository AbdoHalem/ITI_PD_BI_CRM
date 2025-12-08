#include <iostream>
#include <conio.h>
#include <windows.h> 

using namespace std;

/* gotoxy function */
void gotoxy(int x, int y) {
    COORD coord;    // COORD is a structure contains the x and y coordinates
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

#define START_Y 4
/* Problem6: Line Editor */
void PrintLine(char *line, int size){
    int x = 0;                      // cursor position
    char temp;                      // to store the key pressed
    cout << "Enter the line: ";
    gotoxy(x, START_Y);

    int terminate = 0;
    while(!terminate){
        temp = getch();            // Get the next key
        if(temp == 27){            // Esc = 27
            system("cls");
            terminate = 1;
        }
        else if(temp == '\0'){     // extended char code starts with 0
            temp = getch();
            if(temp == 75){        // left arrow
                if(x > 0){
                    gotoxy(--x, START_Y);
                }
            }
            else if(temp == 77){   // right arrow
                if(x < size - 1){
                    gotoxy(++x, START_Y);
                }
            }
            else if(temp == 71){    // Home = 71
                x = 0;
                gotoxy(x, START_Y);
            }
            else if(temp == 79){    // End = 79
                for(int i = x; i < size-1; i++){     // Move the cursor to the end of the line
                    line[i] = ' ';
                }
                x = size - 1;
                gotoxy(x, START_Y);

            }
        }
        else if(temp == 8) {        // Backspace
            if (x > 0) {
                x--;
                gotoxy(x, START_Y);
                cout << " ";        // Delete the character from the screen
                line[x] = '\0';     // Delete the character from the array
                gotoxy(x, START_Y); // Move the cursor back to the previous position
            }
        }
        else if(temp >= 32 && temp <= 126){
            if(x == size - 1){
                line[x] = '\0';
            }
            else{
                gotoxy(x, START_Y);
                cout << temp;
                line[x] = temp;
                x++;
            }   
        }
        else if(temp == 13){        // Enter = 13
            terminate = 1;
            system("cls");
            cout << line;
        }
    }
}

int main() {
    int size = 0;
    cout << "Enter the size of the line: ";
    cin >> size;
    char *line = new char[size];
    for(int i = 0; i < size; i++){
        line[i] = '\0';
    }
    cin.ignore();    // Clear the input buffer

    PrintLine(line, size);
    delete[] line;  // Deallocate the memory
    return 0;
}