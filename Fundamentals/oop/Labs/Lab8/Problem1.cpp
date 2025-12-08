#include <iostream>
#include <cstring>

using namespace std;

#define SUBJECTS 3
class Student{
    int ID;
    char *Name;
    float Grades[SUBJECTS];
public:
    // Default Constructor
    Student();
    // Parameterized Constructor
    Student(int id, char *name, float grades[SUBJECTS]);
    // Default Destructor
    ~Student();
    //Copy Constructor
    Student(Student &student);
    
    // Setters
    void SetID(int ID){this->ID = ID;}
    void SetName(char Name[30]){strcpy(this->Name, Name);}
    void SetGrades(float grades[SUBJECTS]){
        for(int i = 0; i < SUBJECTS; i++){
            this->Grades[i] = grades[i];
        }
    }

    // Getters
    int GetID(){return ID;}
    char* GetName(){return Name;}
    float* GetGrades(){return Grades;}

    // Operators Overloading
    Student operator + (int num);
    Student operator + (char *name);
    Student operator + (Student student);
    Student operator ++();     // ++st;
    Student operator ++ (int d);    // st++;
    operator int();     // Cast to int
    operator char*();   // Cast to char*
    Student& operator = (const Student &student);
    // Student operator = (Student student);
    int operator == (const Student &student); // st1 == st2
};

// Functions
/*5 + st*/
Student operator + (int num, Student &student);
/*"nuha" + st*/
Student operator + (char *name, Student &student);
Student FillStudent();
void PrintStudent(Student &student);
int SumGrades(Student &student);

int main(){
    int number = 0;
    cout << "Enter number of students: ";
    cin >> number;
    Student *arr = new Student[number];
    for(int i = 0; i < number; i++){
        arr[i] = FillStudent();
    }
    for(int i = 0; i < number; i++){
        PrintStudent(arr[i]);
        int sum = SumGrades(arr[i]);
        cout << "Sum of Grades for student " << arr[i].GetID() << " is: " << sum << endl;
    }
    arr[0]++;
    PrintStudent(arr[0]);
    delete[] arr;
    return 0;
}

// Default Constructor
Student::Student(){
    ID = 0;
    Name = new char[40];
    Name[0] = '\0';
    // NumGrades = 0;
    // Grades = new float[NumGrades];
    for(int i = 0; i < SUBJECTS; i++){
        Grades[i] = 0;
    }
}

// Parameterized Constructor
Student::Student(int id, char *name, float grades[SUBJECTS]){
    this->ID = id;
    this->Name = new char[strlen(name) + 1];
    strcpy(this->Name, name);
    for(int i = 0; i < SUBJECTS; i++){
        this->Grades[i] = grades[i];
    }
}

// Default Destructor
Student::~Student(){
    delete(Name);
}

// Copy Constructor
Student::Student(Student &student){
    this->ID = student.ID;
    // delete(this->Name);
    this->Name = new char[strlen(student.Name) + 1];
    strcpy(this->Name, student.Name);
    for(int i = 0; i < SUBJECTS; i++){
        this->Grades[i] = student.Grades[i];
    }
}

// Operators Overloading
/*st + 5*/
Student Student::operator + (int num){
    Student temp(ID+num, Name, Grades);
    return temp;
}

/*st + "John"*/
Student Student::operator + (char *name){
    char newName[strlen(Name) + strlen(name) + 1] = "\0";
    strcpy(newName, this->Name);
    strcat(newName, name);
    Student temp(ID, newName, Grades);
    return temp;
}

/*st1 = st2*/
// Student Student::operator = (Student student){
//     this->ID = student.ID;
//     delete(this->Name);
//     this->Name = new char[strlen(student.Name) + 1];
//     strcpy(this->Name, student.Name);
//     for(int i = 0; i < SUBJECTS; i++){
//         this->Grades[i] = student.Grades[i];
//     }
//     return student;
// }
Student& Student::operator = (const Student &student){
    this->ID = student.ID;
    delete[] this->Name;
    this->Name = new char[strlen(student.Name) + 1];
    strcpy(this->Name, student.Name);
    for(int i = 0; i < SUBJECTS; i++){
        this->Grades[i] = student.Grades[i];
    }
    return *this;
    // return student;    // Gives error!
}

/*st1 + st2*/
Student Student::operator + (Student student){
    Student temp;
    // temp = (*this + student.GetName());   // Add name using 'st + "John"' operator overloading
    char newName[strlen(Name) + strlen(student.Name) + 1] = "\0";
    strcpy(newName, this->Name);
    strcat(newName, student.Name);
    temp.SetName(newName);
    temp.SetID(this->ID + student.ID);  // Add ID
    float grades[SUBJECTS];
    for(int i = 0; i < SUBJECTS; i++){  // Add Grades
        grades[i] = this->Grades[i] + student.Grades[i];
    }
    temp.SetGrades(grades);
    return temp;
}

/*++st*/
Student Student::operator ++ (){
    this->ID += 1;
    return *this;
}

/*st++*/
Student Student::operator ++ (int d){
    Student temp(ID, Name, Grades);
    this->ID += 1;
    return temp;
}

/*Cast to int*/
Student::operator int(){
    return ID;
}

/*Cast to char* */
Student::operator char*(){
    return Name;
}

/*5 + st*/
Student operator + (int num, Student &student){
    Student temp(num, student.GetName(), student.GetGrades());
    temp.SetID(num + student.GetID());
    return temp;
}

/*"nuha" + st*/
Student operator + (char *name, Student &student){
    Student temp(student.GetID(), student.GetName(), student.GetGrades());
    char newName[strlen(name) + strlen(student.GetName()) + 1] = "\0";
    strcpy(newName, name);
    strcat(newName, student.GetName());
    temp.SetName(newName);
    return temp;
}

/*st1 == st2*/
int Student::operator == (const Student &student){
    int res = 0;
    if(this->ID == student.ID){
        if(strcmp(this->Name, student.Name) == 0){
            for(int i = 0; i < SUBJECTS; i++){
                if(this->Grades[i] == student.Grades[i]){
                    res = 1;
                }
                else{
                    res = 0;
                    break;
                }
            }
        }
    }
    return res;
}

Student FillStudent(){
    Student student;
    // Set Name
    cout << "Enter student name: ";
    char name[30] = "\0";
    cin >> name;
    student.SetName(name);
    // Set ID
    cout << "Enter student ID: ";
    int ID; cin >> ID;
    student.SetID(ID);
    // Set Grades
    float *grades = student.GetGrades();
    for(int i = 0; i < SUBJECTS; i++){
        cout << "Enter Grade for subject " << i+1 << ": ";
        cin >> grades[i];
    }
    return student;
}

void PrintStudent(Student &student){
    cout << "Student Name is: " << student.GetName() << endl;
    cout << "Student ID is: " << student.GetID() << endl;
    // int NumGrades = student.GetNumGrades();
    cout << "Grades for the " << SUBJECTS << " subjects" << endl;
    float *grades = student.GetGrades();
    for(int i = 0; i < SUBJECTS; i++){
        cout << "Subject " << i+1 << ": " << grades[i] << endl;
    }
}

int SumGrades(Student &student){
    int sum = 0;
    // int NumGrades = student.GetNumGrades();
    float *grades = student.GetGrades();
    for(int i = 0; i < SUBJECTS; i++){
        sum += grades[i];
    }
    return sum;
}