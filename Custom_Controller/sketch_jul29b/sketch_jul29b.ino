#include <SerialCommand.h>

SerialCommand sCmd;

int pot = A0;
int potReadValue=0;

int switchPin = 5;
int switchReadValue;

void setup() {
  pinMode(switchPin, INPUT);
  Serial.begin(9600);
  while(!Serial);
  
  sCmd.addCommand("ECHO", echoHandler);
  sCmd.addCommand("PING", pingHandler);
}

void loop() {
  if(Serial.available()>0){
    sCmd.readSerial();
  }
  //pingHandler();
}

void pingHandler(){
  //Serial.println("PONG");
  //read the potentiomenter
  potReadValue = analogRead(pot);
  //read the switch
  switchReadValue = digitalRead(switchReadValue);
  Serial.println(String(potReadValue));
  Serial.println(String(switchReadValue));
  
}

void echoHandler(){
  char *arg;
  arg = sCmd.next();
  if(arg != NULL){
    Serial.println(arg);
  }
  else{
    Serial.println("nothing to echo");
  }
}

