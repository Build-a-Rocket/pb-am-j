#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

#define NRF24_SCLK 8
#define NRF24_MISO 9
#define NRF24_MOSI 10
#define NRF24_CS   0
#define NRF24_CE   1

RF24 radio(NRF24_CE, NRF24_CS);

const uint8_t address[5]=[0, 0, 0, 0, 1];

const uint8_t channel = 125;

void setup() {
  Serial.begin(2000000);
  while(!Serial);

  radio.begin()

  radio.openReadingPipe(0, address);
  radio.setChannel(channel);
  radio.startListening();

}

void loop() {
  byte text[32] = {0};
  while (radio.available())
  {
    radio.read(&text, sizeof(text));
    Serial.write(text, sizeof(text));
  }

}
