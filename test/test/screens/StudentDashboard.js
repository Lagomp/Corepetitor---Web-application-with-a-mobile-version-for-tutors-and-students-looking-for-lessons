import React from "react";
import { View, Text, StyleSheet, ScrollView } from "react-native";
import { TouchableOpacity } from "react-native";

const StudentDashboard = ({ navigation }) => {
  return (
    <ScrollView>
      <View style={styles.container}>
        <Text style={styles.title}>Witaj na koncie studenta.</Text>

        <View style={styles.card}>
          <TouchableOpacity
            onPress={() => navigation.navigate("Table")}
            title="My Enrollments"
            style={styles.button}
          >
            <Text style={styles.buttonText}>Zarezerwowane spotkania</Text>
          </TouchableOpacity>
        </View>

        <View style={styles.card}>
          <TouchableOpacity
            onPress={() => navigation.navigate("AdminEnrollments")}
            title="Messages"
            style={styles.button}
          >
            <Text style={styles.buttonText}>Wiadomości</Text>
          </TouchableOpacity>
        </View>

        <View style={styles.card}>
          <TouchableOpacity
            onPress={() => navigation.navigate("StudentEnrollments")}
            title="Messages"
            style={styles.button}
          >
            <Text style={styles.buttonText}>Edytuj profil</Text>
          </TouchableOpacity>
        </View>

        <View style={styles.card}>
          <TouchableOpacity
            onPress={() => navigation.navigate("Login")}
            title="My Enrollments"
            style={styles.button}
          >
            <Text style={styles.buttonText}>Wyloguj się</Text>
          </TouchableOpacity>
        </View>
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    backgroundColor: "#F8FCD4",
  },
  title: {
    fontSize: 30,
    fontWeight: "bold",
    marginBottom: 20,
    textAlign: "center",
    marginTop: 20,
    fontWeight: "900",
  },
  title1: {
    fontSize: 30,
    fontWeight: "bold",
    marginBottom: 30,
    textAlign: "center",
    marginTop: 50,
    fontWeight: "900",
  },
  card: {
    backgroundColor: "#fff",
    borderRadius: 10,
    padding: 20,
    marginBottom: 20,
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
  },
  cardTitle: {
    fontSize: 18,
    fontWeight: "bold",
    marginBottom: 10,
    textAlign: "center",
    fontWeight: "900",
  },
  cardContent: {
    fontSize: 16,
    textAlign: "center",
    color: "blue",
    fontStyle: "italic",
    fontWeight: "900",
  },
  button: {
    width: "100%",
    height: 50,
    backgroundColor: "brown",
    borderRadius: 5,
    alignItems: "center",
    justifyContent: "center",
  },
  buttonText: {
    color: "#fff",
    fontSize: 18,
    fontWeight: "bold",
  },

  tableHeader: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
    overflow: "scroll",
  },
  headerText: {
    fontWeight: "bold",
    fontSize: 16,
    width: "30%",
  },
  tableRow: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
  },
  rowText: {
    fontSize: 16,
    width: "30%",
  },
});

export default StudentDashboard;
