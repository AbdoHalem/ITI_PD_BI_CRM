#include <iostream>
#include <cstring>

using namespace std;

#define SUBJECTS 5
class Student{
    int ID;
    char Name[30];
    int NumGrades;
    float *Grades;
public:
    // Default Constructor
    Student();
    // Default Destructor
    ~Student();
    //Copy Constructor
    Student(Student &student);
    // Setters
    void SetID(int ID){this->ID = ID;}
    void SetName(char Name[30]){strcpy(this->Name, Name);}
    void SetNumGrades(int NumGrades){this->NumGrades = NumGrades;}
    void SetGrades(int *Grades){
        for(int i = 0; i < this->NumGrades; i++){
            this->Grades[i] = Grades[i];
        }
    }
    // Getters
    int GetID(){return ID;}
    char* GetName(){return Name;}
    int GetNumGrades(){return NumGrades;}
    float* GetGrades(){return Grades;}
};

// Functions
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
    delete(arr);
    return 0;
}

// Default Constructor
Student::Student(){
    ID = 0;
    Name[0] = '\0';
    NumGrades = 0;
    Grades = new float[NumGrades];
    for(int i = 0; i < this->NumGrades; i++){
        Grades[i] = 0;
    }
}

// Default Destructor
Student::~Student(){
    delete[] Grades;
}
// Copy Constructor
Student::Student(Student &student){
    this->ID = student.ID;
    strcpy(this->Name, student.Name);
    for(int i = 0; i < SUBJECTS; i++){
        this->Grades[i] = student.Grades[i];
    }
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
    // Set Number of Grades
    cout << "Enter number of grades: ";
    int NumGrades; cin >> NumGrades;
    student.SetNumGrades(NumGrades);
    // Set Grades
    for(int i = 0; i < student.GetNumGrades(); i++){
        cout << "Enter Grade for subject " << i+1 << ": ";
        float *grades = student.GetGrades();
        cin >> grades[i];
    }
    return student;
}

void PrintStudent(Student &student){
    cout << "Student Name is: " << student.GetName() << endl;
    cout << "Student ID is: " << student.GetID() << endl;
    int NumGrades = student.GetNumGrades();
    cout << "Grades for the " << NumGrades << " subjects" << endl;
    float *grades = student.GetGrades();
    for(int i = 0; i < NumGrades; i++){
        cout << "Subject " << i+1 << ": " << grades[i] << endl;
    }
}

int SumGrades(Student &student){
    int sum = 0;
    int NumGrades = student.GetNumGrades();
    float *grades = student.GetGrades();
    for(int i = 0; i < NumGrades; i++){
        sum += grades[i];
    }
    return sum;
}