#include <Servo.h>
Servo ServoX;
Servo ServoY;

String serialData;

void setup() {
  ServoX.attach(9);
  ServoY.attach(8); 
  Serial.begin(9600);
  Serial.setTimeout(10);
  ServoX.write(0);
  ServoY.write(0);
}

void loop() {
  
}

void serialEvent(){
  serialData = Serial.readString();

  ServoX.write(parseDataX(serialData));
  ServoY.write(parseDataY(serialData));
}

int parseDataX(String data){
  data.remove(data.indexOf("Y"));
  data.remove(data.indexOf("X"), 1);

  return data.toInt();
}


int parseDataY(String data){
  data.remove(0, data.indexOf("Y") + 1);

  return data.toInt();
}
