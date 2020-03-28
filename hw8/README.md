# CS220 - HW8

Please read carefully the problems and fill out the `RationalNumberOperation.fs`
file. We recommend you to modify only the `RationalNumberOperation.fs` file for
your homework. Even if you have local modifications, you should not push your
modifications to the other files. Please do not use imperative language features
such as for loop and while loop to solve these problems. The deadline is
23:59:59, 4/15.

### Problem

In this homework, you are going to implement functions for rational number
arithmetics. You can see the definition of the type `RationalNumber` in the
`Types.fs` file. There are about thirteen functions with `failwith`
expression in `RationalNumberOperation.fs` file, and your goal is to remove the
`failwith` expressions and implement those functions.

### Test Case Generation

Currently there is only one test case for this homework. However, you should add
your own test case (only one test case) in this homework. Try to think about
corner cases when you create your test case. Also, please use 10 sec. timeout
for each test: use `[<TestMethod; Timeout(10000)>]` attribute for your testing
function.

If you create a wrong test case, which should not work on a correct
implementation, you will get -10 pts (out of 100 regular pts).

### Grading

In this homework, we will take all your test cases along with TAs' test cases
and run them against all other students' implementations. Let us suppose that
there are N students, and TAs created P test cases. Then we will have (N + P)
test cases in total. We will run every student's implementation with all the
test cases, and give score based on it. If you can come up with a test case that
triggers a difficult-to-trigger bug, then you will get relatively high score.

We will give 100 pts based on our `P` TA test cases, and will give +10 extra
points based on the N student test cases.

### Error Cases

Since our rational number type internally uses `uint32`, you may hit integer
overflows when dealing with large numbers. In such cases, you should raise the
`ComputationErrorException` exception defined in the `Types.fs`. Error handling
is a part of this homework, and it can directly affect your grades. Therefore,
you should not ask any question regarding error handling. It is your
responsibility to think about corner cases, and handle them correctly.

#### YOU SHOULD NOT ASK QUESTIONS ABOUT ERROR HANDLING. WE WILL DEDUCT YOUR POINTS IF YOU DO SO.
