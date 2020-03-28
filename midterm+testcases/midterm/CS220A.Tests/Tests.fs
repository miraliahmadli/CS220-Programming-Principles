namespace CS220A.Tests

open CS220

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module CharManager =
  let invPasswordChar =
    [| 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15; 16; 17; 18; 19; 20
       21; 22; 23; 24; 25; 26; 27; 28; 29; 30; 31; 34; 36; 38; 39; 40; 41; 42
       43; 45; 47; 58; 59; 60; 61; 62; 63; 64; 91; 92; 93; 94; 95; 96; 123; 124
       125; 126; 127; 128; 129; 130; 131; 132; 133; 134; 135; 136; 137; 138; 139
       140; 141; 142; 143; 144; 145; 146; 147; 148; 149; 150; 151; 152; 153; 154
       155; 156; 157; 158; 159; 160; 161; 162; 163; 164; 165; 166; 167; 168; 169
       170; 171; 172; 173; 174; 175; 176; 177; 178; 179; 180; 181; 182; 183; 184
       185; 186; 187; 188; 189; 190; 191; 192; 193; 194; 195; 196; 197; 198; 199
       200; 201; 202; 203; 204; 205; 206; 207; 208; 209; 210; 211; 212; 213; 214
       215; 216; 217; 218; 219; 220; 221; 222; 223; 224; 225; 226; 227; 228; 229
       230; 231; 232; 233; 234; 235; 236; 237; 238; 239; 240; 241; 242; 243; 244
       245; 246; 247; 248; 249; 250; 251; 252; 253; 254; 255 |]
    |> Array.map (fun i -> Text.Encoding.Default.GetString [| byte i |])

  let invEmailChar =
    [| 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15; 16; 17; 18; 19; 20
       21; 22; 23; 24; 25; 26; 27; 28; 29; 30; 31; 32; 33; 34; 35; 36; 37; 38
       39; 40; 41; 42; 43; 44; 47; 58; 59; 60; 61; 62; 63; 64; 65; 66; 67; 68
       69; 70; 71; 72; 73; 74; 75; 76; 77; 78; 79; 80; 81; 82; 83; 84; 85; 86
       87; 88; 89; 90; 91; 92; 93; 94; 95; 96; 123; 124; 125; 126; 127; 128
       129; 130; 131; 132; 133; 134; 135; 136; 137; 138; 139; 140; 141; 142
       143; 144; 145; 146; 147; 148; 149; 150; 151; 152; 153; 154; 155; 156
       157; 158; 159; 160; 161; 162; 163; 164; 165; 166; 167; 168; 169; 170
       171; 172; 173; 174; 175; 176; 177; 178; 179; 180; 181; 182; 183; 184
       185; 186; 187; 188; 189; 190; 191; 192; 193; 194; 195; 196; 197; 198
       199; 200; 201; 202; 203; 204; 205; 206; 207; 208; 209; 210; 211; 212
       213; 214; 215; 216; 217; 218; 219; 220; 221; 222; 223; 224; 225; 226
       227; 228; 229; 230; 231; 232; 233; 234; 235; 236; 237; 238; 239; 240
       241; 242; 243; 244; 245; 246; 247; 248; 249; 250; 251; 252; 253; 254
       255 |]
    |> Array.map (fun i -> Text.Encoding.Default.GetString [| byte i |])

module TestHelper =
  let assertSome x = Assert.IsTrue (Option.isSome x)

  let assertNone x = Assert.IsTrue (Option.isNone x)

open CharManager
open TestHelper

[<TestClass>]
type TestClass () =
    /// UserID Creation Tests
    /// Total: 15pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("a")>]
    [<DataRow("aaa")>]
    [<DataRow("aaaaa")>]
    [<DataRow("aaaaaaa")>]
    [<DataRow("aaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaa")>]
    member __.``Valid userid test`` s =
      UserID.create s |> assertSome

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaaaa")>]
    member __.``Invalid userid test`` s =
      UserID.create s |> assertNone

    /// Password Creation Tests
    /// Total: 15pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("aA1 ")>]
    [<DataRow("aA1!")>]
    [<DataRow("aA1#")>]
    [<DataRow("aA1%")>]
    [<DataRow("aA1.")>]
    [<DataRow("aA1,")>]
    member __.``Valid password test 1`` s =
      Password.create s |> assertSome

    [<TestMethod;Timeout(10000)>]
    member __.``Valid password test 2`` () =
      Array.init 36 (fun i -> String.replicate (i + 1) "a" + "A1.")
      |> Array.iter (Password.create >> assertSome)

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("")>]
    [<DataRow("AAA1!")>]
    [<DataRow("aaa1!")>]
    [<DataRow("aaaaA!")>]
    [<DataRow("aaaaA1")>]
    member __.``InValid password test 1`` s =
      Password.create s |> assertNone

    [<TestMethod;Timeout(10000)>]
    member __.``InValid password test 2`` () =
      Array.map (fun i -> "aA1 " + i) invPasswordChar
      |> Array.iter (Password.create >> assertNone)

    /// UserName Creation Tests
    /// Total: 15pts
    (* UserName Creation Tests *)
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("a")>]
    [<DataRow("aaa")>]
    [<DataRow("aaaaa")>]
    [<DataRow("aaaaaaa")>]
    [<DataRow("aaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaa")>]
    member __.``Valid username test`` s =
      UserName.create s |> assertSome

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")>]
    member __.``Invalid username test`` s =
      UserName.create s |> assertNone

    /// Email Creation Tests
    /// Total: 25pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("aaaa@domain.com")>]
    [<DataRow("bbbb@domain.com")>]
    [<DataRow("cccc@domain.com")>]
    [<DataRow("dddd@domain.com")>]
    member __.``Valid email test `` s =
      EMail.create s |> assertSome

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@domain.com")>]
    [<DataRow("aaaa@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")>]
    [<DataRow(".nope@domain.com")>]
    [<DataRow("-nope@domain.com")>]
    [<DataRow("nope@.domain.com")>]
    [<DataRow("nope@-domain.com")>]
    [<DataRow("nope.@domain.com")>]
    [<DataRow("nope-@domain.com")>]
    [<DataRow("nope@domain.com.")>]
    [<DataRow("nope@domain.com-")>]
    [<DataRow("aaaaaa-domain-com")>]
    [<DataRow("aaaaaa@domain@com")>]
    member __.``Invalid email test 1`` s =
      EMail.create s |> assertNone

    [<TestMethod;Timeout(10000)>]
    member __.``Invalid email test 2`` () =
      Array.map (fun i -> "aaaaaa" + i + "@domain.com") invEmailChar
      |> Array.iter (EMail.create >> assertNone)
    [<TestMethod;Timeout(10000)>]
    member __.``Invalid email test 3`` () =
      Array.map (fun i -> "aaaaaa@domain" + i + ".com") invEmailChar
      |> Array.iter (EMail.create >> assertNone)

    /// XXX: Whatever this case is error or not,
    /// XXX: this should not raise an exception.
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow("aaaaaa@")>]
    [<DataRow("@aaaaaa")>]
    [<DataRow("aaaaaaaaaaaa")>]
    [<DataRow("")>]
    member __.``Edge email test`` s =
      EMail.create s |> ignore
