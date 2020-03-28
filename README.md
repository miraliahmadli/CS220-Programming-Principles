# Programming Principles Course
# CS220, Spring Semester, 2019

My solutions to the Programming Principles course assignments.

Structure of repository:

```
├── README.md
├── hwXX
│   ├── README.md
│   ├── HWxx.sln
│   ├── HWxx
│   │   ├── You will write your code here
│   └── etc...
├── etc...
```

For testing your work, run the following commands inside homework directroy (hwXX):

```
dotnet build  
dotnet test  
```

__NOTE__: If you get error regarding .NET core SDK version, you can either install the mentioned version or you can change Target Framework in HWxx.Tests.fsproj file ([for example](https://github.com/miraliahmadli/CS220-Programming-Principles/blob/master/hw2/HW2.Tests/HW2.Tests.fsproj#L4))

For each homework, homework descriptions are given in the hwXX.pdf file.
