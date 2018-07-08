import time
import digitalio
from adafruit_hid.keyboard import Keyboard
from adafruit_hid.keycode import Keycode
import board

###
#
# A simple three key macro hardware helper for Unity Editor scene Play/Pause/Step Frame
# Richard Walsh
# July 6, 2018
#
# Based on: https://learn.adafruit.com/arcade-button-control-box/overview
#
###

# The button pins we'll use, each will have an internal pullup
buttonpins = [board.D12, board.D11, board.D10]
ledpins = [board.A0, board.A1, board.A2]

# Unity keyboard shortcut keys that matter for this
pKey = Keycode.P
controlKey = Keycode.CONTROL
shiftKey = Keycode.SHIFT
altKey = Keycode.ALT

# The keyboard object
kbd = Keyboard()

# Our array of button objects
buttons = []
leds = []

# Button States and Repeat Stuff
buttonState = [False, False, False]
stepButtonRepeatedFirstTime = False
monoTonicLastRepeat = 0
monoTonicNow = 0
repeatDelayFirstTime = 0.5
repeatDelay = 0.1
currentRepeatDelay = repeatDelayFirstTime

# Make all pin objects, make them inputs with pullups
for pin in buttonpins:

    button = digitalio.DigitalInOut(pin)
    button.direction = digitalio.Direction.INPUT
    button.pull = digitalio.Pull.UP
    buttons.append(button)
	
for pin in ledpins:
    led = digitalio.DigitalInOut(pin)
    led.direction = digitalio.Direction.OUTPUT
    leds.append(led)

# Grab reference to our LED so we can make it blink to reflect tests are working
boardLED = digitalio.DigitalInOut(board.D13)
boardLED.switch_to_output()

# TODO: Get rid of this?
print("Waiting for button presses")


# Main loop (loops forever, polling keys)
while True:

    
    #
    # Button 0: Play
    #
    if not buttons[0].value:
    
        if buttonState[0] == False:
        
            buttonState[0] = True
            
            print("PLAY")
            kbd.press(controlKey, pKey)
            
            # Don't forget to release the keys!
            kbd.release_all()
            
    else:
        buttonState[0] = False
    
    
    #
    # Button 1: Pause
    #
    if not buttons[1].value:
    
        if buttonState[1] == False:
        
            buttonState[1] = True
            
            print("PAUSE")
            kbd.press(controlKey, shiftKey, pKey)
            
            # Don't forget to release the keys!
            kbd.release_all()
            
    else:
        buttonState[1] = False

        
    #
    # Button 2: Step
    #
    if not buttons[2].value:
    
        if buttonState[2] == False:
        
            monoTonicLastRepeat = time.monotonic()
            
            currentRepeatDelay = repeatDelayFirstTime
            stepButtonRepeatedFirstTime = False
            
            buttonState[2] = True
            
            print("STEP")
            kbd.press(controlKey, altKey, pKey)
            
            # TODO: Check this?
            leds[2].value = True

            # Don't forget to release the keys!
            kbd.release_all()
        
    else:
        buttonState[2] = False
     
    
    #
    # Button repeating for "Step" button
    #
    if buttonState[2] == True:

        monoTonicNow = time.monotonic()
        
        if (monoTonicNow - monoTonicLastRepeat) > currentRepeatDelay:
        
            # After waiting for a bit longer the first time, make 2nd to Nth repeats faster
            if stepButtonRepeatedFirstTime == False:
                stepButtonRepeatedFirstTime = True
                currentRepeatDelay = repeatDelay
            

            print("STEP (REPEAT)")
            kbd.press(controlKey, altKey, pKey)
            
            # Don't forget to release the keys!
            kbd.release_all()
            
            monoTonicLastRepeat = time.monotonic()
        

    # Board LED for debug visualization
    if buttonState[0] or buttonState[1] or buttonState[2]:
        boardLED.value = True
    else:
        boardLED.value = False

    
    # TODO: Add feature to disable LED lights (maybe press all 3 buttons 
    # to toggle LEDs on and off, and wrap the led.value part in "if toggled 
    # on" block
    
    # Make the arcade button LED lights reflect button state
    leds[0].value = buttonState[0];
    leds[1].value = buttonState[1];
    leds[2].value = buttonState[2];
        
    # Main loop sleep time
    time.sleep(0.01)
        