#include <iostream>
#include <fstream>

using namespace std;

int main(){
    /* Write to text file */
    ofstream textFile("test.txt");
    if(textFile.is_open()){
        cout << "Enter text in test.txt file: ";
        char txt[100];
        cin.getline(txt, 100);
        textFile << txt;
        textFile.close();
    }
    /* Write to binary file */
    ofstream binFile("test2.dat", ios::out | ios::binary);
    if(binFile.is_open()){
        cout << "Enter text in test2.dat file: ";
        char txt[100];
        cin.getline(txt, 100);
        binFile.write(txt, sizeof(txt));
        binFile.close();
    }

    /* Read from text file */
    ifstream intextFile("test.txt");
    if(intextFile.is_open()){
        cout << "Content in test.txt file: " << endl;
        char txt[100];
        intextFile.getline(txt, 100);
        cout << txt << endl;
        intextFile.close();
    }
    /* Read from binary file */
    ifstream inbinFile("test2.dat", ios::in | ios::binary);
    if(inbinFile.is_open()){
        cout << "Content in test2.dat file: " << endl;
        char txt[100];
        inbinFile.read(txt, 100);
        cout << txt << endl;
        inbinFile.close();
    }
    return 0;
}