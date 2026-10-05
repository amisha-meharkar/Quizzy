// Import the Google Generative AI module from the @google/generative-ai package
import { GoogleGenerativeAI } from "@google/generative-ai";

// Define your API key
const API_KEY = "AIzaSyDiLPlMGzwZU3tbEG_0txNR1zS17TMw-xc"; // Replace "YOUR_API_KEY" with your actual API key

// Initialize the GoogleGenerativeAI instance with your API key
const genAI = new GoogleGenerativeAI(API_KEY);

// Function to get the current season based on the date
function getCurrentSeason(date) {
    const month = date.getMonth() + 1; // Month is zero-indexed, so add 1

    if (month >= 3 && month <= 5) {
        return 'spring';
    } else if (month >= 6 && month <= 8) {
        return 'summer';
    } else if (month >= 9 && month <= 11) {
        return 'fall';
    } else {
        return 'winter';
    }
}

// Function to generate content using a prompt
async function generateContentWithPrompt(arr) {
    // Get the current date and time
    const currentDate = new Date();
    const currentTime = currentDate.toTimeString();
    const currentDay = currentDate.toLocaleDateString('en-US', { weekday: 'long' });
    const currentSeason = getCurrentSeason(currentDate);

    // Define the prompt based on the current time, day, season, and coupon names
    const reqii = `
Given the following list of coupon names:
${arr.join(',')},
please suggest the best one considering the current time (${currentTime}), day (${currentDay}), and season (${currentSeason}), and only give me the coupon name.
`;

    // Choose the generative model (e.g., "gemini-pro")
    const model = genAI.getGenerativeModel({ model: "gemini-pro" });

    try {
        // Generate content based on the prompt using the model
        const result = await model.generateContent(reqii);

        // Extract the response from the result
        const response = await result.response;

        // Get the generated text from the response
        const text = await response.text();

        // Log the generated text to the console
        console.log("Generated text:", text);

        // Set the text content of the element with id="response"
        $("#response").text(text);

    } catch (error) {
        // Handle any errors that might occur during content generation
        console.error("Error generating content:", error);
    }
}

// Make an AJAX request to get the coupon names
$.ajax({
    type: "GET",
    url: "https://localhost:44314/CouponAPI/PassCouponNames",
    success: function (result) {
        const arr = result; // Store the coupon names
        console.log(result);
        generateContentWithPrompt(arr); // Call the function inside the success callback
    },
    error: function (error) {
        alert('Error Occurred!');
    }
});
