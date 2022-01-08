#include <Stepper.h>

// The 
#define TOTAL_MOTOR_STEPS 4096
// Recommended max RPM at 5V per motor spec
#define MAX_RPM 6 

//const int CompassStepsForOneDegree = TOTAL_MOTOR_STEPS / 360;
//const int FineAdjustmentStep = TOTAL_MOTOR_STEPS / 720;
const int FineAdjustmentStep = 1;

// create an instance of the stepper class, specifying
// the number of steps of the motor and the pins it's
// attached to
Stepper stepper(TOTAL_MOTOR_STEPS, 4, 5, 6, 7);

const int ButtonPinCW = 9;
const int ButtonPinACW = 8;
const int ButtonPinResetHome = 10;

const int LEDPinRed = 2;
const int LEDPinGreen = 3;

int buttonStateCW = 0;
int buttonStateACW = 0;
int buttonStateResetHome = 0;
bool wasHoldingResetButton = false;

//const int TargetDegreesFromHome = 90;

int currentStepsFromHome = 0;

//const int TargetStepsFromHome = 512;
//int targetStepsFromHome = 512;
int targetStepsFromHome = 0;

//int currentTargetHeadingDegrees = 0;



// Receive data test
int dataReceivedState = 0;

const byte numChars = 32;
char receivedSerialChars[numChars];
boolean newData = false;

int parsedHeadingInteger = 0;


int previousHeadingDegrees = 0;
int currentHeadingDegrees = 0;



void setup()
{
  
  Serial.begin(9600);
  Serial.println("Stepper test!");
  
  // initialize the pushbutton pin as an input:
  pinMode(ButtonPinCW, INPUT);
  pinMode(ButtonPinACW, INPUT);
  pinMode(ButtonPinResetHome, INPUT);

  pinMode(LEDPinRed, OUTPUT);
  pinMode(LEDPinGreen, OUTPUT);

  // set the speed of the motor to 30 RPMs
  stepper.setSpeed(MAX_RPM);
  
}

void loop()
{

  // read the state of the pushbutton values:
  buttonStateCW = digitalRead(ButtonPinCW);
  buttonStateACW = digitalRead(ButtonPinACW);
  buttonStateResetHome = digitalRead(ButtonPinResetHome);

  // If user is currently holding the reset button, allow fine adjustments
  if(buttonStateResetHome == HIGH)
  {

    // Set debug LEDs to match button states
    digitalWrite(LEDPinRed, buttonStateCW);
    digitalWrite(LEDPinGreen, buttonStateACW);

    Serial.println("HOLDING RESET");
    wasHoldingResetButton = true;
  
    // Allow for fine adjustments clockwise
    if(buttonStateCW == HIGH)
    {
      
      Serial.println("ClockWise!");
      stepper.step(FineAdjustmentStep);
      
    }
    // ...and anti-clockwise
    else if(buttonStateACW == HIGH)
    {
      
      Serial.println("Anti-ClockWise!");
      stepper.step(-FineAdjustmentStep);
      
    }

  }
  else
  {

    // If the user just RELEASED the reset home button, reset to zero
    if(wasHoldingResetButton)
    {

      Serial.println("Reset Home!");
      wasHoldingResetButton = false;
      currentStepsFromHome = 0;

    }
    else
    {

      // Seek current target position //
      if(currentStepsFromHome != targetStepsFromHome)
      {

        // And I am currently less than target
        if(currentStepsFromHome < targetStepsFromHome)
        {
  
          // Move ONE degree forwards toward target
          currentStepsFromHome += 1;
          //stepper.step(CompassStepsForOneDegree);
          stepper.step(1);

          /*
          Serial.print("Moving toward target! (");
          Serial.print(currentStepsFromHome);
          Serial.print("/");
          Serial.print(targetStepsFromHome);
          Serial.println(")");
          */
          
        }
        // Otherwise if I am currently greater than target
        else if(currentStepsFromHome > targetStepsFromHome)
        {
  
          // Move ONE degree backwards toward target
          currentStepsFromHome -= 1;
          stepper.step(-1);

          /*
          Serial.print("Moving toward target! (");
          Serial.print(currentStepsFromHome);
          Serial.print("/");
          Serial.print(targetStepsFromHome);
          Serial.println(")");
          */
          
        }
        
      }

    }
     

    // Receive data test //

    receiveDataWord();
    showNewNumber();

    /*
    if(newData == true)
    {
      digitalWrite(LEDPinGreen, HIGH);
      digitalWrite(LEDPinRed, LOW);
    }
    else
    {
      digitalWrite(LEDPinGreen, LOW);
      digitalWrite(LEDPinRed, HIGH);
    }
    */
    
    /*
    char receivedValue;

    if(Serial.available() > 0)  
    {          

       receivedValue = Serial.read();  

       if(receivedValue == '1')
       {
        
          dataReceivedState = 1;
          // Set debug LEDs to match button states
          
          digitalWrite(LEDPinGreen, HIGH);
          digitalWrite(LEDPinRed, LOW);

       }
       else if(receivedValue == '0')
       {

          dataReceivedState = 0;
          digitalWrite(LEDPinGreen, LOW);
          digitalWrite(LEDPinRed, HIGH);
        
       }
       else
       {

          digitalWrite(LEDPinGreen, LOW);
          digitalWrite(LEDPinRed, LOW);

       }

        Serial.print("RECEIVED'");
        Serial.print(receivedValue);
        Serial.println("'");

       //delay(50);
       
    }
    */
    

  }
    
}

void receiveDataWord() 
{
  
    static byte index = 0;
    char endMarker = '\n';
    char receivedChar;
    
    if (Serial.available() > 0) 
    {
      
        receivedChar = Serial.read();

        if (receivedChar != endMarker) 
        {
          
            receivedSerialChars[index] = receivedChar;
            index++;
            
            if (index >= numChars)
            {
                index = numChars - 1;
            }
            
        }
        else
        {
          
          // Terminate the string
          receivedSerialChars[index] = '\0';
          index = 0;
          newData = true;
          
        }
        
    }
    
}

void showNewNumber()
{

    if (newData == true)
    {
      
        parsedHeadingInteger = 0;
        parsedHeadingInteger = atoi(receivedSerialChars);

        // Assume we're given value 0-360 degrees
        // TODO: Calculate target HEADING in degrees

        // Rotation of 90 degrees is 512 steps
        // Rotation of 180 degrees is 1024 steps
        // Rotation of 270 degrees is 1024 steps
        // Rotation of 360 degrees is 2048 steps

        // But we need to check where we are now vs target. If we're at 355 degrees, and want
        // to go to 5 degrees, we need to go UP to 259, 0, then to 5, not back around to 
        // 350, then back to zero

        // One degree is 2048/360 = 5.688888888889
        
        previousHeadingDegrees = currentHeadingDegrees;
        currentHeadingDegrees = parsedHeadingInteger;

        int delta = currentHeadingDegrees - previousHeadingDegrees;

        if(abs(delta) > 180)
        {

          if(delta < 0)
          {
            delta += 360;
          }
          else
          {
            delta -= 360;
          }
        
        }

        // Now that we have our delta, apply it in terms of steps difference from current target steps
        // E.g. if we had heading of 5 degrees, and new heading 355, our delta is -10, which is target 
        // motor steps of -10 * 5.688888888889
        targetStepsFromHome += delta * 5.688888888889;
        
        
        //Serial.print("Received ");
        //Serial.print(receivedSerialChars);
        Serial.print(", Data as Number=");
        Serial.print(parsedHeadingInteger);
        Serial.print(", NEW HEADING=");
        Serial.print(currentHeadingDegrees);
        Serial.print(", TARGETSTEPS=");
        Serial.print(targetStepsFromHome);
        Serial.print(", DELTA=");
        Serial.println(delta);
        
        
        newData = false;
    
    }
    
}
