# Midterm

In this exam, your goal is to make your program (i.e., functions with FIXME
comment) work in any circumstances. You can use any technique you want (except
for the mutable keyword and imperative features), but you should be aware that
our test case will run only for 10 seconds as usual. You don't need to worry
about tail recursion for this exam.

Again, the goal here is to make your program work in all possible
circumstances. Then you will get a full score. We do not accept any question
during the midterm.

### Individual Work

This should be done entirely by yourself. No collaboration. No discussion.

### Introduction

You are going to implement a user registeration database system. The internals
of the database is not known, and your goal is to implement it in F#. We provide
the basic skeleton code for the system, and you can modify the code to achieve
this goal. While impelementing the system, your should carefully read comments
given in the skeleton code in order to meet the requriements.

### Basic Structure

All the types are defined in the `CS220` namespace. Each "value" used in the
system has its own type and the corresponding module. For example, `EMail.fs`
file contains the type definition for e-mail addresses, and corresponding
functions in the `CS220.EMail` module.

### Web Server and Database (DB)

`WebServer.fs` file mimics a web server, and there are three different kinds of
web forms defined in `WebForms.fs`. You can imagine a user running a web browser
would connect to the web server, and send some data to the server using a web
form. Whenever there is a request from a user, the web server will process it
using three different functions depending on their request type. There are three
kinds of requests: (1) user registration, (2) user de-registration, and (3) user
information update. Each request will be processed by the web server to update
the DB.

```
+------+  request (WebForms.fs)   +--------------+        +--------+
| User | -----------------------> | WebServer.fs | <----> | UserDB |
+------+                          +--------------+        +--------+
```


### Design Principle

You will implement a functional database. Therefore, each DB-related functions
(defined in `UserDB.fs`) will carry `UserDB`. Mutable or imperative features are
not allowed in this midterm. We will get zero point if you use them.

### Grading

Grading will be done as usual, but there is no test project in the current
solution. We will upload them when we start grading. Instead, you will be able
to run the project with `dotnet run` command because the project is created as a
console application. You are recommended to modify the `main` function for
debugging.

- If your program doesn't compile, you will get zero point. But we will give
  partial points: we will add unit tests for each function, and you will get
  partial points based on the result of our unit tests, which will be added
  after the midterm.

- If you use `mutable`, `for`, or `while` keyword, you will get zero point.
