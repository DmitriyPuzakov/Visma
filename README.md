# Visma Test Task

In this task the BankAccount class implementation is shown.
For better usability Web UI is provided on [http://visma.puzakov.me](http://visma.puzakov.me)

This class coud be used for converting Bank Account Number from clear text format to electronic format which is consist of 14 digit.

![Interface](http://visma.puzakov.me/readme1.jpg)

Here you can put account number in short format and get it in long format and also validate check digit. If there's a wrong check digit in the given short number, no long number could be provided.

## Class description

BankAccount class implements IBankAccount interface with two public methods

```
string GetLongFormat();
bool IsCheckDigitCorrect();
```

Usage example:

```
var bank = new BankAccount("123456-785");
var longNumber = bank.GetLongFormat();
var checkDigitValid = bank.IsCheckDigitCorrect();
```
