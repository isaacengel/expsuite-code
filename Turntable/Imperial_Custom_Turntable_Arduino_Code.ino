#include <SPI.h>
#include <Ethernet.h>
#include <EthernetUdp.h>
#include <OSCBundle.h>

#define enaPin 8
#define stepPin 7
#define dirPin 6
#define stepsPerRevolution 800

byte mac[] = { 
  0xA8, 0x61, 0x0A, 0xAE, 0x6D, 0xBA }; //regarding ethernet shield

IPAddress ip(192, 168, 0, 2); //static IP address

int serverPort  = 6000; //incoming port
int delayTime = 625; // default delaytime between steps, approx 1 degree/second

//Create UDP message object
EthernetUDP Udp;

void setup(){
  pinMode(stepPin, OUTPUT);
  pinMode(dirPin, OUTPUT);
  pinMode(enaPin, OUTPUT);
  digitalWrite(dirPin, LOW);
  digitalWrite(enaPin, LOW); //ENABLE left Low by default, to prevent overheating
//  Serial.begin(9600); //Uncomment Serial lines for trouble shooting
//  Serial.println(Ethernet.localIP());
//  Serial.println("OSC test");

  // start the Ethernet connection:
  Ethernet.begin(mac, ip);   
  if (Ethernet.begin(mac) == 0) {
//    Serial.println("Failed to configure Ethernet using DHCP");
    // no point in carrying on, so do nothing forevermore:
    while(true);
  }
  // print your local IP address:
//  Serial.print("Arduino IP address: ");
//  for (byte thisByte = 0; thisByte < 4; thisByte++) {
//    // print the value of each byte of the IP address:
//    Serial.print(Ethernet.localIP()[thisByte], DEC);
//    Serial.print(".");
//  }

  Udp.begin(serverPort);
}

void loop(){
  OSCMessage msg;
  receiveOscMessage(msg);
  //process received messages
  if(!msg.hasError()){
    msg.dispatch("/Clockwise", clockwise);
    msg.dispatch("/Anticlockwise", anticlockwise);
    msg.dispatch("/Speed", velocity);
  }
}

void receiveOscMessage(OSCMessage& msg){
  int size;
  if((size = Udp.parsePacket()) > 0){
    while(size--)
      msg.fill(Udp.read());
  }
}

void clockwise(OSCMessage& msg){ //Function for clockwise rotation
  rotate(msg, true);
}

void anticlockwise(OSCMessage& msg){ //Function for anticlockwise rotation
  rotate(msg, false);
}

void rotate(OSCMessage& msg, bool clockwise){

  int degrees = msg.getInt(0);

//  Serial.print("Degrees: ");
//  Serial.println(degrees);

  digitalWrite(enaPin, HIGH);
  digitalWrite(dirPin, clockwise ? HIGH : LOW);
  delay(500);
//  Serial.println("Start rotation");
  for(int i = 0; i < degrees; i++){
    for (int x = 0; x < stepsPerRevolution; x++) {
      digitalWrite(stepPin, HIGH);
      delayMicroseconds(delayTime);
      digitalWrite(stepPin, LOW);
      delayMicroseconds(delayTime);
    }
    OSCMessage msg;
    receiveOscMessage(msg);
    if(!msg.hasError() && msg.fullMatch("/Stop")){
      break;
    }
  }
//  Serial.println("Stop rotation");
  digitalWrite(enaPin, LOW);
  delay(500);
}

void velocity(OSCMessage& msg){ //Set the rotation speed in degrees per second. The quickest recommended value is 5, default is 1.
  float degreesPerSecond = msg.getFloat(0);
  // 2*delayTime*stepsPerRevolution = 1000000 / degreesPerSecond
  delayTime = round(500000/(stepsPerRevolution*degreesPerSecond));
//  Serial.print("degrees per second: ");
//  Serial.println(degreesPerSecond);
//  Serial.print("delay time: ");
//  Serial.println(delayTime);
}
