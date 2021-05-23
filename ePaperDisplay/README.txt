Project Background:
------------------

https://learn.adafruit.com/epaper-display-featherwing-quote-display/arduino-setup

But modified to do other things (world clock)



Drivers and Libraries:
---------------------

Note: Use CP210x_Windows_Drivers

USB Drivers: https://www.silabs.com/developers/usb-to-uart-bridge-vcp-drivers


Arduino Boards Library: https://raw.githubusercontent.com/espressif/arduino-esp32/gh-pages/package_esp32_index.json

-Arduino IDE 1.8+
-Enter one of the release links above into Additional Board Manager URLs field. You can add multiple URLs, separating them with commas.
-Then Open Boards Manager from Tools > Board menu and install esp32 platform (and don't forget to select your ESP32 board from Tools > Board menu after installation).
-Once installed, use the Adafruit ESP32 Feather board in the dropdown
-For Upload speed we've found 921600 baud works great.


Other info on interfacing with Arduino IDE: https://learn.adafruit.com/adafruit-huzzah32-esp32-feather/using-with-arduino-ide?gclid=EAIaIQobChMI34qHm_HZ8AIVmW1vBB3JUwXpEAAYASAAEgLWVfD_BwE


Other Hardware Notes:
--------------------
Use display def for "Adafruit_SSD1680 epd(250, 122, EPD_DC, EPD_RESET, EPD_CS, SRAM_CS, EPD_BUSY);". The hardware page says it is SSD1675, but that is outdated and newer boards are actually SSD1680! Otherwise, the display may seem like it doesn't work.



secrets.h:
---------

Initial file committed, then blocked from the code repo via .gitignore file, but must be present with this content:

<FILE BEGIN>

#ifndef _SECRET_H THEN
#define _SECRET_H

// define your WIFI SSID and password in this file
#define WIFI_SSID "Your_SSID_Name_Here"
#define WIFI_PASSWORD "Your_Password_Here"

#endif

<FILE END>

