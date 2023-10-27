<script lang="ts">
	const example1 = `
encounter[]:
end
`.trim();

	const example2 = `
encounter["Bosses"]:
  music = 42
end
`.trim();

	const example3 = `
music
victory_music
normal_bgm
victory_normal_bgm
advantage_bgm
victory_advantage_bgm
disadvantage_bgm
victory_disadvantage_bgm
`.trim();
</script>

<h2>Encounters (Battles)</h2>
<p>
	Battles, also known as <em>Encounters</em>, can have the battle music and victory music changed.
	Both can also be changed depending on the battle's <em>context</em>.
</p>
<blockquote>
	The battle's <em>context</em> can be: a normal battle, player's advantage, player's disadvantage
	(enemy advantage). For example, <em>Persona 4 Golden</em> plays <em>Time to Make History</em> for
	<b>normal</b> battles, and <em>Reach Out to the Truth</em> for player <b>advantage</b>.
</blockquote>
<h3>Encounter Block</h3>
<div class="row">
	<div class="column">
		To change a battle's music, you start by creating an <em>Encounter Block</em>.
	</div>
	<div class="column">
		<pre><code>{example1}</code></pre>
	</div>
</div>
<p>
	Between the <code>[ ]</code> brackets, you set what encounter you are editing. You can use an encounter's
	ID:
</p>
<pre><code>encounter[100]</code></pre>
<p>or a collection of encounter IDs:</p>
<pre><code>encounter["Bosses"]</code></pre>
<h3>Encounter Commands</h3>
<p>Inside the block, you can then set the encounter(s)'s music using commands:</p>
<pre><code>{example2}</code></pre>
<p>For example, the code above will set all boss battles to play song ID 42.</p>
<div class="row">
	<div class="column">
		<strong> <em>Difference between <code>music</code> and <code>context_bgm</code>?</em></strong>
		<p>
			Using <code>music</code> will always play that music, no matter the context. Using
			<code>advantage_bgm</code> will only play that music if the battle context is advantage.
		</p>
	</div>
	<div class="column">
		<strong>Available Commands</strong>
		<pre><code>{example3}</code></pre>
	</div>
</div>
