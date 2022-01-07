#include <Stepper.h>

// change this to the number of steps on your motor
#define TOTAL_MOTOR_STEPS 1024
#define MAX_RPM 60
//#define FINE_ADJUST_STEP_INCREMENT TOTAL_MOTOR_STEPS / 360

const int CompassStepsForOneDegree = TOTAL_MOTOR_STEPS / 360;

const int FineAdjustmentStep = TOTAL_MOTOR_STEPS / 360;

// create an instance of the stepper class, specifying
// the number of steps of the motor and the pins it's
// attached to
Stepper stepper(TOTAL_MOTOR_STEPS, 4, 5, 6, 7);

const int buttonPinCW = 8;
const int buttonPinACW = 9;

const int buttonPinResetHome = 10;

int buttonStateCW = 0;
int buttonStateACW = 0;
int buttonStateResetHome = 0;

bool wasHoldingResetButton = false;




int currentStepsFromHome = 0;
int currentDegreesFromHome = 0;

int targetDegreesFromHome = 90;
int targetStepsFromHome = 90 * CompassStepsForOneDegree;





void setup()
{
  
  Serial.begin(9600);
  Serial.println("Stepper test!");
  

  // initialize the pushbutton pin as an input:
  pinMode(buttonPinCW, INPUT);
  pinMode(buttonPinACW, INPUT);
  pinMode(buttonPinResetHome, INPUT);

  // set the speed of the motor to 30 RPMs
  stepper.setSpeed(MAX_RPM);
  
}

void loop()
{

  // read the state of the pushbutton values:
  buttonStateCW = digitalRead(buttonPinCW);
  buttonStateACW = digitalRead(buttonPinACW);
  buttonStateResetHome = digitalRead(buttonPinResetHome);

  // If user is currently holding the reset button, allow fine adjustments
  if(buttonStateResetHome == HIGH)
  {

    wasHoldingResetButton = true;
    
    Serial.println("HOLDING RESET");

  
    // Allow for fine adjustments clockwise
    if(buttonStateCW == HIGH)
    {
      Serial.println("ClockWise!");
      stepper.step(FineAdjustmentStep);
    }
    // ...and anti-clockwise
    else  if(buttonStateACW == HIGH)
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
      currentStepsFromHome = 0;
      currentDegreesFromHome = 0;
      wasHoldingResetButton = false;
      
    }
    else
    {

      // Seek current target position //

      // If target is positive
      if(targetStepsFromHome > 0)
      {

        // And I am currently less than target
        if(currentDegreesFromHome < targetDegreesFromHome)
        {

          // Move toward target
          Serial.print("Moving toward target! (");
          Serial.print(currentDegreesFromHome);
          Serial.print("/");
          Serial.print(targetDegreesFromHome);
          Serial.println(")");
          
          currentDegreesFromHome += 1;
          
          stepper.step(CompassStepsForOneDegree);

          delay(10);
          
        }

      }
     
    }

  }
    
}
