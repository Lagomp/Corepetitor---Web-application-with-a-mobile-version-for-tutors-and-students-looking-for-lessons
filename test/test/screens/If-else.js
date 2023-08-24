import React, { useState } from 'react';
import { View, Text, Button } from 'react-native';

export default function MyComponent() 
{
  const [buttonClicked, setButtonClicked] = useState(false);

  function handleButtonClick() 
  {
    if (buttonClicked) 
    {
      setButtonClicked(false);
    } 
    else 
    {
      setButtonClicked(true);
    }
  }

  return (
    <View>
      <Button
        title={buttonClicked ? 'Clicked!!!' : 'Click'}
        onPress={handleButtonClick}
      />
      {buttonClicked ? 
      (
        <Text>The button has been clicked!</Text>
      ) : 
      (
        <Text>Click the button to see a message</Text>
      )}
    </View>
  );
}

