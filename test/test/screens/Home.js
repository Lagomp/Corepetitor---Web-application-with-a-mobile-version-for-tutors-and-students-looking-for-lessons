import React from "react";
import { View, Text, StyleSheet, TouchableOpacity } from "react-native";

const Home = ({ navigation }) => {
  return (
    <View
      style={{
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Text
        style={{
          fontSize: 40,
          color: "red",
          padding: 30,
        }}
      >
        Home
      </Text>
      <TouchableOpacity
        onPress={() => navigation.navigate("Dashboard")}
        style={styles.button}
      >
        <Text style={styles.buttonText}>Dashboard</Text>
      </TouchableOpacity>

      <TouchableOpacity
        onPress={() => navigation.navigate("If-else")}
        style={styles.button1}
      >
        <Text style={styles.buttonText}>Btnn</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  button: {
    width: "50%",
    height: 50,
    backgroundColor: "brown",
    borderRadius: 5,
    alignItems: "center",
    justifyContent: "center",
  },
  button1: {
    width: "50%",
    height: 50,
    backgroundColor: "indigo",
    borderRadius: 5,
    alignItems: "center",
    justifyContent: "center",
    marginTop: 10,
  },
  buttonText: {
    color: "#fff",
    fontSize: 20,
    fontWeight: "bold",
  },
});

export default Home;
