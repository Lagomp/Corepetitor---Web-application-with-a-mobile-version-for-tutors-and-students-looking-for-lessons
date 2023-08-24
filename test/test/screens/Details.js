import React from "react";
import { View ,Text, TouchableOpacity,StyleSheet } from "react-native";
import { useNavigation } from '@react-navigation/native';
import SyncStorage from 'sync-storage';


const GoBackButton = () => {
    const navigation = useNavigation();

    function showFoo(){
        alert(SyncStorage.get('foo'));
    }

    const goBack = () => {
      navigation.goBack();
    };
  return(
    <View style={{
        flex:1,justifyContent:'center',alignItems:'center'
    }}>
        <TouchableOpacity style={styles.btn} onPress={()=> navigation.navigate('Table')}>
            <Text style={styles.btnTxt}>Table Screen</Text>
        </TouchableOpacity>
           <Text style={{
                   fontSize:30,
                   padding:20,
                   textAlign:'center'
                   }}>This is Details Screen.</Text>
        <TouchableOpacity
        style={styles.btn1}
        onPress = {showFoo} >
            <Text style={styles.btnTxt1}>Go Back</Text>
        </TouchableOpacity>
    </View>
        )
  }

const styles = StyleSheet .create({
    container: {
        flex: 1,
        padding: 20,
      },
    btn:{
        width: '80%',
        height: 50,
        backgroundColor: 'brown',
        borderRadius: 5,
        alignItems: 'center',
        justifyContent: 'center',
    },

    btnTxt:{
        color: '#fff',
        fontSize: 18,
        fontWeight: 'bold',
    },

    btn1:{
          width: '50%',
          height: 50,
          backgroundColor: 'skyblue',
          borderRadius: 5,
          alignItems: 'center',
          justifyContent: 'center',
    },
    btnTxt1:{
        color: '#fff',
        fontSize: 18,
        fontWeight: 'bold',
    },

});


export default GoBackButton






