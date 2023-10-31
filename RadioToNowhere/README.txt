Warm wooden CB style desktop radio, see the shining, orange or yellow warm lit gauges. Silver steel toggles, red power indicator lamp. Usb powered, ambient white noise, woooooey tuning interference type sound effects available. Morse code buttons, squelch PTT button.

Desktop radio to nowhere

For working remotely, or being or feeling isolated "on the moon" remote team etc


Radio Frequency Dial:
-How to meaningfully "tune" to nonsense channels with good droning static whirring feedback?
--Maybe using audio sample mixing through sum/average
-->Add sample at timestamp from "static" file to "signal" file, and average
-->Could put weight on "how much static to mix in" based on "how close the dial is to the station" value
-->Would require all samples have same bitrate, sample rate, are mono, etc.

--http://hyperphysics.phy-astr.gsu.edu/hbase/Electronic/opampvar5.html

-or maybe have one Arduino command several MP3 modules via serial commands and have each module playback a different file from its SD card


Maybe Teensy:
-See https://forum.arduino.cc/t/play-multiple-audio-files-polyphony/409133/10
-and https://youtu.be/wqt55OAabVs?t=547

This seems cool:
https://www.sparkfun.com/products/13660


Alternatively, just broadcast audio through a very near field AM transmitter, and use an actual AM receiver to do the tuning and static "for real"?
-https://www.instructables.com/AM-Transmitter-With-Arduino/




See TestLayout folder:

Basic prototype style layout using real hardware. Does not have Morse code interface yet. Maybe a fold out brass Morse code "paddle" or something idk. Something over complicated for very old technology


Reference folder:

-The Shining
-GE MASTR VHF base station transceiver

Morse Code

PUTIKEEG Mini Classical Morse Code Key - CW Morse Code Keys Automatic Morse Aluminum Alloy Radio Ham Send Telegram Morse Code Key with Silicone Anti-Slip...



Emergency Bands:

https://www.itu.int/en/ITU-R/information/Pages/emergency-bands.aspx

http://hamgallery.com/gallery/A/37freqchart.htm


Electronics:

-Speaker
https://www.adafruit.com/product/1314

-Amp
https://www.adafruit.com/product/987

-Audio Player
https://www.adafruit.com/product/1381
