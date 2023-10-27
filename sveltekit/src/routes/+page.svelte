<script lang="ts">
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
	const example1: string = `
// Create a constant for randomized bgm.
// This constant will randomly play 10 songs, 698 up to 707.
const randomBgm = random_song(698, 707)

// Encounter block that uses a collection.
// The block will make all battles in Yukiko's Castle
// have randomized bgm.
encounter["Yukiko's Castle"]:
  music = randomBgm
end

// Encounter block that will affect all battles.
// The block will make all battles use specialist for the victory
// screen, if the player has advantage.
encounter["all"]:
  victory_advantage_bgm = song("specialist")
end

// Override main menu music.
// Now randomly plays 5 songs.
global_bgm[19]:
  music = random_song(800, 804)
end

// Set floor 1 to play snowflakes.
floor[1]:
  music = song("snowflakes")
end
`.trim();
</script>

<div class="container">
	<div class="row">
		<div class="column">
			<h1>Persona Music Script</h1>
			<h2>Introduction</h2>
			<p>
				<em>Persona Music Script</em> is a script+tool for easily customizing music Persona games.
			</p>
			<h2>Quickstart</h2>
			<p>For people that have some experience creating mods.</p>
			<ol>
				<li>Download and extract <i>BGME Framework</i> to your Reloaded II mods folder: TODO</li>
				<li>
					Create a new, or edit an existing, Reloaded mod and add <i>BGME Framework</i> as a dependency.
				</li>
				<li>In your mod's folder, create a new folder named <code>BGME</code>.</li>
				<li>
					Inside the <code>BGME</code> folder, create a new text file with the extension
					<code>.pme</code>. This will be the your mod's first music script file. You can add any
					amount of music script files in the
					<code>BGME</code> folder.
				</li>
				<li>Open your music script file with a text editor.</li>
				<li>
					<Link url="{base}/docs">Read the documentation</Link> and make any changes you want. Changes
					to music scripts will apply in real-time if the game is running.
				</li>
				<li>
					For adding and using new music, see the section for your specific game: <Link
						url="{base}/bgme-framework"
						text="Adding Music"
					/>.
				</li>
			</ol>
			<h2>Examples</h2>
			<pre><code>{example1}</code></pre>
		</div>
	</div>
</div>
