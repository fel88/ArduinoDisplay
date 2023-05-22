#include <Wire.h>
#include "OLED_SH1106.h"
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

#define OLED_RESET 4
OLED_SH1106 display(OLED_RESET);

#define SCREEN_WIDTH 128 // OLED display width, in pixels
#define SCREEN_HEIGHT 64 // OLED display height, in pixels
//#define OLED_RESET    -1 // Reset pin # (or -1 if sharing Arduino reset pin)



const int buttonPin = 3;    
const int buttonPin2 = 2;   
const int buttonPin3 = 6;    
const int buttonPin4 = 5;   
 
 
void setup() {  
  
  Serial.begin(9600); 
  while (! Serial); 
  Serial.println(F("started..")); 
  
  display.begin(SSD1306_SWITCHCAPVCC, 0x3C); //Start the OLED display
  display.clearDisplay();
  //display.setRotation(2);
  display.display();
  
  display.setTextColor(WHITE);
  display.setTextSize(1); 
  
  display.setCursor(32,12);
  display.setTextSize(2);     
       
  pinMode(buttonPin, INPUT);
  pinMode(buttonPin2, INPUT);
  pinMode(buttonPin3, INPUT);
  pinMode(buttonPin4, INPUT);     
}


int buttonState = 0;         
int buttonState2 = 0;        
int buttonState3 = 0;        
int buttonState4 = 0;        

int lastButtonState = 0;     
int lastButtonState2 = 0;    
int lastButtonState3 = 0;    
int lastButtonState4 = 0;    

String str1;
String str2;
String str3;
String titleStr;

void loop() {
 buttonState = digitalRead(buttonPin);
 buttonState2 = digitalRead(buttonPin2);
 buttonState3 = digitalRead(buttonPin3);
 buttonState4 = digitalRead(buttonPin4);

 if (buttonState == HIGH && lastButtonState==LOW) {        
    Serial.println(F("btn1"));
  } 
  if (buttonState2 == HIGH && lastButtonState2 == LOW) {
    Serial.println(F("btn2"));
  } 
  if (buttonState3 == HIGH && lastButtonState3 == LOW) {
    Serial.println(F("btn3"));
  } 
  if (buttonState4 == HIGH && lastButtonState4 == LOW) {
    Serial.println(F("btn4"));
  } 

  lastButtonState=buttonState;
  lastButtonState2=buttonState2;
  lastButtonState3=buttonState3;
  lastButtonState4=buttonState4;

 if (Serial.available() > 0) {  
  String temp= Serial.readStringUntil('\n');
  temp.trim();                       
  bool good=false;
  if (temp.startsWith(F("str1="))){
    str1=temp.substring(5);
    good=true;
    
  }else
  if (temp.startsWith(F("str2="))){
    str2=temp.substring(5);
    good=true;
  }else  
  if (temp.startsWith(F("str3="))){
    str3=temp.substring(5);
    good=true;
  }else
  if (temp.startsWith(F("title="))){
    titleStr=temp.substring(6);
    good=true;
  }
  if(good){
     Serial.println(F("ok"));
     Serial.flush();
  }
}


    display.clearDisplay();
    
    display.setCursor(0,0);              
    display.setTextColor(WHITE);
    display.setTextSize(2); 
    display.print(titleStr);
    display.setTextSize(1);  


    display.setCursor(0,25);
    display.print(str1);
    display.setCursor(0,35);
    display.print(str2);
    display.setCursor(0,45);
    display.print(str3);
    display.setCursor(30,25);
    
    display.display();
}