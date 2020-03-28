namespace HW1.tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  let gitfile = "gitpractice.txt"
  let gitLines = IO.File.ReadLines gitfile |> Seq.toArray
  let infofile = "myinfo.csv"
  let infoLines = IO.File.ReadLines infofile |> Seq.toArray

  [<TestMethod>]
  member __.``Did you read the tutorial and changed gitpractice.txt?``() =
    let answerLine = gitLines.[1].ToLower ()
    Assert.IsTrue (answerLine.StartsWith ("> yes"))

  [<TestMethod>]
  member __.``Does your CSV file have just two lines?``() =
    Assert.AreEqual (2, Array.length infoLines)

  [<TestMethod>]
  member __.``Does your CSV file has the correct header?``() =
    let expected = "student_id,email,github_id"
    Assert.AreEqual (expected, infoLines.[0])

  [<TestMethod>]
  member __.``Does your CSV file contain a valid student ID?``() =
    let studentID = infoLines.[1].Split(',').[0] |> Convert.ToUInt64
    Assert.IsTrue (studentID > 0UL)

  [<TestMethod>]
  member __.``Does your CSV file contain a valid email?``() =
    let email = infoLines.[1].Split(',').[1]
    let emailID = email.Split('@').[0]
    let emailDomain = email.Split('@').[1]
    Assert.IsTrue (email.Contains ("@"))
    Assert.IsTrue (String.length emailID > 0)
    Assert.IsTrue (String.length emailDomain > 0)

  [<TestMethod>]
  member __.``Does your CSV file contain a valid github ID?``() =
    let gitid = infoLines.[1].Split(',').[2]
    Assert.IsTrue (String.length gitid > 0)
