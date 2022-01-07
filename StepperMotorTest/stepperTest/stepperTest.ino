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

int buttonStateCW = 0;
int buttonStateACW = 0;
int buttonStateResetHome = 0;
bool wasHoldingResetButton = false;

//const int TargetDegreesFromHome = 90;
//int currentDegreesFromHome = 0;
int currentStepsFromHome = 0;
//const int TargetStepsFromHome = 90 * CompassStepsForOneDegree;
const int TargetStepsFromHome = 512;


//
// AdjustmentInSteps = ((Newcompass-oldcompass)/360)*TOTAL_MOTOR_STEPS ?
//


void setup()
{
  
  Serial.begin(9600);
  Serial.println("Stepper test!");
  
  // initialize the pushbutton pin as an input:
  pinMode(ButtonPinCW, INPUT);
  pinMode(ButtonPinACW, INPUT);
  pinMode(ButtonPinResetHome, INPUT);

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

    Serial.println("HOLDING RESET");
    wasHoldingResetButton = true;
  
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
      wasHoldingResetButton = false;
      currentStepsFromHome = 0;

    }
    else
    {

      // Seek current target position //

      // And I am currently less than target
      if(currentStepsFromHome < TargetStepsFromHome)
      {

        // Move ONE degree toward target
        currentStepsFromHome += 1;
        //stepper.step(CompassStepsForOneDegree);
        stepper.step(1);

        Serial.print("Moving toward target! (");
        Serial.print(currentStepsFromHome);
        Serial.print("/");
        Serial.print(TargetStepsFromHome);
        Serial.println(")");
        
      }

    }
     
    

  }
    
}
