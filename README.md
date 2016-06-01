# NaturalLanguageDateTime
Natural language date time expression parse in c#

## Usage notes
```c#
using NaturalLanguageDateTime.NLDT;

...
DateTime yesterday = NLDateTime.ParseString("yesterday");
DateTime today = NLDateTime.ParseString("today");
DateTime tomorrow = NLDateTime.ParseString("tomorrow");
```

Parse 

```c#
DTime dt = NLDateTime.Evaluate("yesterday").AsDTime();
DTime dt = NLDateTime.Evaluate("today").AsDTime();
DTime dt = NLDateTime.Evaluate("tomorrow").AsDTime();
DTime dt = NLDateTime.Evaluate("1 day afted today").AsDTime();
DTime dt = NLDateTime.Evaluate("1 week after tomorrow").AsDTime();
DTime dt = NLDateTime.Evaluate("1 day after tomorrow").AsDTime();
DTime dt = NLDateTime.Evaluate("1 day before today").AsDTime();

DateTime datetime = DTime.DateTime;

```
