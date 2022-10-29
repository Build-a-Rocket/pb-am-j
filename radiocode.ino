#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

#define NRF24_SCLK 8
#define NRF24_MISO 9
#define NRF24_MOSI 10
#define NRF24_CS 0
#define NRF24_CE 1

RF24 radio(NRF24_CE, NRF24_CS);

// address of our radio
const uint8_t address[5] = {0, 0, 0, 0, 1};

// the frequency our radio listens
const uint8_t channel = 125;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(2000000);
  while(!Serial);

  radio.begin();
  
  //set the address
  radio.openReadingPipe(0, address);
  radio.setChannel(channel);
  radio.startListening();

}

void loop() {
  // put your main code here, to run repeatedly:
  byte text[32] = {0};
  while (radio.available())
  {
    radio.read(&text, sizeof(text));
    Serial.write(text, sizeof(text));
  }

}
