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
int delayTime = 400; //default delaytime between steps
int stopRequested = 0; // flag to indicate if a stop has been requested

//Create UDP message object
EthernetUDP Udp;

void setup(){
  pinMode(stepPin, OUTPUT);
  pinMode(dirPin, OUTPUT);
  pinMode(enaPin, OUTPUT);
  digitalWrite(dirPin, LOW);
  digitalWrite(enaPin, LOW); //ENABLE left Low by default, to prevent overheating
  Serial.begin(9600); //Uncomment Serial lines for trouble shooting
  Serial.println(Ethernet.localIP());
  //Serial.println("OSC test");

  // start the Ethernet connection:
  Ethernet.begin(mac, ip);   
  if (Ethernet.begin(mac) == 0) {
    //Serial.println("Failed to configure Ethernet using DHCP");
    // no point in carrying on, so do nothing forevermore:
    while(true);
  }
  // print your local IP address:
  //Serial.print("Arduino IP address: ");
  //for (byte thisByte = 0; thisByte < 4; thisByte++) {
    // print the value of each byte of the IP address:
    //Serial.print(Ethernet.localIP()[thisByte], DEC);
    //Serial.print("."); 
  //}

  Udp.begin(serverPort);
}

void loop(){
  //process received messages
  OSCMsgReceive();
} 

void OSCMsgReceive(){ //Function for recieving OSC messages
  OSCMessage msgIN;
  int size;
  if((size = Udp.parsePacket())>0){
    while(size--)
      msgIN.fill(Udp.read());
    if(!msgIN.hasError()){
      msgIN.route("/Clockwise",clockwise);
      msgIN.route("/Anticlockwise", anticlockwise);
      msgIN.route("/Speed", velocity);
    }
  }
}

void OSCMsgReceiveCheckIfStopped(){ //Function for recieving OSC messages, but only Stop messages during movement
  OSCMessage msgIN;
  int size;
  if((size = Udp.parsePacket())>0){
    while(size--)
      msgIN.fill(Udp.read());
    if(!msgIN.hasError()){
      msgIN.route("/Stop",stop);
    }
  }
}

void stop(OSCMessage &msg, int addrOffset){ // Function for stopping rotation
  int value = msg.getInt(0);
  if(value == 1){
    stopRequested = 1;
  }
}

void clockwise(OSCMessage &msg, int addrOffset ){ //Function for clockwise rotation

  int value = msg.getInt(0);

  //Serial.print("Value = : ");
  //Serial.println(value);

  digitalWrite(enaPin, HIGH);
  digitalWrite(dirPin, HIGH);
  delay(500);
  for(int i = 0; i < value; i++){
    for (int x = 0; x < stepsPerRevolution; x++){
    delayMicroseconds(delayTime);
    digitalWrite(stepPin, HIGH);
    delayMicroseconds(delayTime);
    digitalWrite(stepPin, LOW);
    delayMicroseconds(delayTime);
   }
   OSCMsgReceiveCheckIfStopped();
   if(stopRequested == 1) {
    stopRequested = 0;
    break;
   }
  }
  digitalWrite(enaPin, LOW);
  delay(500);
}

void anticlockwise(OSCMessage &msg, int addrOffset ){ //Function for anticlockwise rotation

  int value = msg.getInt(0);

  //Serial.print("Value = : ");
  //Serial.println(value);

  digitalWrite(enaPin, HIGH);
  digitalWrite(dirPin, LOW);
  delay(500);
  for(int i = 0; i < value; i++){
    for (int x = 0; x < stepsPerRevolution; x++) {
    delayMicroseconds(delayTime);
    digitalWrite(stepPin, HIGH);
    delayMicroseconds(delayTime);
    digitalWrite(stepPin, LOW);
    delayMicroseconds(delayTime);
   }
   OSCMsgReceiveCheckIfStopped();
   if(stopRequested == 1) {
    stopRequested = 0;
    break;
   }
  }
  digitalWrite(enaPin, LOW);
  delay(500);
}

void velocity(OSCMessage &msg, int addrOffset ){ //Set the delay time between steps. The quickest recommended value is 100, default is 400.
  
  int value = msg.getInt(0);
  
  delayTime = value;  
}
