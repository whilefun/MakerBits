import time
import digitalio
from adafruit_hid.keyboard import Keyboard
from adafruit_hid.keycode import Keycode
import board

###
#
# A basic toggle switch with LED indicator lights for a 2 channel Push-to-Talk voip headset
# Richard Walsh
# April 6, 2020
#
###


# The button pins we'll use, each will have an internal pullup
buttonpins = [board.D10, board.D11]
ledpins = [board.A0, board.A1]

# Keyboard keycodes
controlKey = Keycode.CONTROL
shiftKey = Keycode.SHIFT
altKey = Keycode.ALT

# The keyboard object
kbd = Keyboard()



# Our array of button objects
buttons = []
leds = []


# Startup Flags - assume dirty startup state until clear
cleanStartup = False


# Button States and Repeat Stuff
buttonState = [False, False, False]
stepButtonRepeatedFirstTime = False
monoTonicLastRepeat = 0
monoTonicNow = 0
ledBlinkRepeatDelay = 0.5


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

        
# Main loop (loops forever, polling keys)
while True:
    
    
    # We only do clean button checks if our first start up loop cleared
    if cleanStartup:
    
        if buttons[0].value:
        
            # if key was up last time, this is a press.
            if buttonState[0] == False:
                kbd.press(controlKey, shiftKey)
                                
            buttonState[0] = True
            
        # if not, was it down last frame?
        else:
        
            # if key was down last time, this is a release
            if buttonState[0] == True:
                kbd.release(controlKey, shiftKey)
                
            buttonState[0] = False
        
        
        
        # if hardware key is down,
        if buttons[1].value:
        
            # if key was up last time, this is a press.
            if buttonState[1] == False:
                kbd.press(controlKey, altKey)
                
            buttonState[1] = True
            
        # if not, was it down last frame?
        else:
        
            # if key was down last time, this is a release
            if buttonState[1] == True:
                kbd.release(controlKey, altKey)
               
            buttonState[1] = False
        

        
        # Board LED for debug visualization
        if buttonState[0] or buttonState[1]:
            boardLED.value = True
        else:
            boardLED.value = False

        
        # Make LED lights reflect hardware state
        leds[0].value = buttonState[0];
        leds[1].value = buttonState[1];
    
    
    
    else:
        
        monoTonicNow = time.monotonic()
        
        if (monoTonicNow - monoTonicLastRepeat) > ledBlinkRepeatDelay:
        
            #cleanStartup = True

            #if not buttons[0].value and not buttons[1].value:
            
            if buttons[0].value == False and  buttons[1].value == False:
                
                cleanStartup = True
                print("Achieved clean startup!")



            else:
            
                print("Still have dirty startup!")
                
                if(leds[0].value == True):
                
                    leds[0].value = False
                    leds[1].value = False
                    
                else:
                    leds[0].value = True
                    leds[1].value = True
            
            
            monoTonicLastRepeat = time.monotonic()
    
    
    # Main loop sleep time
    time.sleep(0.01)