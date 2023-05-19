#include <Adafruit_GFX.h>      //Libraries for the OLED and BMP280
#include <Adafruit_SSD1306.h>

#define SCREEN_WIDTH 128 // OLED display width, in pixels
#define SCREEN_HEIGHT 64 // OLED display height, in pixels
#define OLED_RESET    -1 // Reset pin # (or -1 if sharing Arduino reset pin)

Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET); //Declaring the display name (display)

const int buttonPin = 3;     // the number of the pushbutton pin
const int buttonPin2 = 2;     // the number of the pushbutton pin
const int buttonPin3 = 6;     // the number of the pushbutton pin
const int buttonPin4 = 5;     // the number of the pushbutton pin
 
 
void setup() {  
  
  Serial.begin(115200); 
  Serial.println("started.."); 
  
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
    Serial.println("btn1");
  } 
  if (buttonState2 == HIGH && lastButtonState2 == LOW) {    
    
    Serial.println("btn2");
  } 
  if (buttonState3 == HIGH && lastButtonState3 == LOW) {    
    
    Serial.println("btn3");
  } 
  if (buttonState4 == HIGH && lastButtonState4 == LOW) {
    Serial.println("btn4");
  } 
  lastButtonState=buttonState;
  lastButtonState2=buttonState2;
  lastButtonState3=buttonState3;
  lastButtonState4=buttonState4;

 if (Serial.available() > 0) {  
  String temp= Serial.readStringUntil('\n');  //read until timeout
  temp.trim();                        // remove any \r \n whitespace at the end of the String
  if (temp.startsWith("str1=")){
    str1=temp.substring(5);
  }else
  if (temp.startsWith("str2=")){
    str2=temp.substring(5);
  }else  
  if (temp.startsWith("str3=")){
    str3=temp.substring(5);
  }else
  if (temp.startsWith("title=")){
    titleStr=temp.substring(6);
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
